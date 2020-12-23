@model TemplateContext<Presentation>

@{
    Presentation contextObject = Model.Object;
    var animateTransitions = Model.Global.Get<bool>("animateTransitions").ToString().ToLower();
    var pagesCount = contextObject.Slides.Count;
}


var currentVisiblePage = 1;
var maxVisiblePage = @pagesCount;

$(document).ready(function(){
      
    if (@animateTransitions) {
        InitTransitions();
    }
});


function InitTransitions() {
    PlayTransition('#slide-1');
    
    $('#PrevSlide').show();
    $('#NextSlide').show();
      
    $("#PrevSlide").click(function(){ ShowPrev(); });
    $("#NextSlide").click(function(){ ShowNext(); });
}

function PlayTransition(slideId) {
    var slide = $(slideId);
    var transitionType = slide.data('transitionType');
    
    if(transitionType === 'Fade') {
        Fade(slideId); 
    } else if(transitionType === 'Push') {
        Push(slideId);        
    } else {
        $(slideId).show();    
    }
}

function Fade(slideId) {
    var duration = getDuration(slideId); 
    
    $(slideId).fadeIn(duration);
}

function Push(slideId) {
    var prevSlide = $(slideId).prev();
    var prevSlideId = prevSlide.attr('id');
    var selector = '#' + prevSlideId + " .slideContent";
    var height = $('#' + prevSlideId).height() * -1;
    var duration = getDuration(slideId);
        
    anime({ 
        targets: selector, 
        translateY: height,
        duration: duration,
        complete: function() {
            $(slideId).show();
        } 
    });
}

function getDuration(slideId) {
    var transitionSpeed = $(slideId).data("transitionSpeed");
    
    var duration = 700;
    if(transitionSpeed == 'Fast') { duration = 400; } 
    else if(transitionSpeed == 'Medium') { duration = 1000; } 
    else if(transitionSpeed == 'Slow') { duration = 2500; } 
    
    return duration;
}

function ShowNext() {
      
    if (currentVisiblePage < maxVisiblePage) {
            
        $('#slide-' + currentVisiblePage++).hide();
        PlayTransition('#slide-' + currentVisiblePage);            
    }
    RedrawButtons();
}

function ShowPrev() {
      
    if (currentVisiblePage > 1) {
            
        $('#slide-' + currentVisiblePage--).hide();
        PlayTransition('#slide-' + currentVisiblePage);
    }
    RedrawButtons();
}

function RedrawButtons() { 

    $("#PrevSlide").children().prop('disabled',false);
    $("#NextSlide").children().prop('disabled',false);
      
    if (currentVisiblePage == 1) 
        $("#PrevSlide").children().prop('disabled',true);
    else if (currentVisiblePage == maxVisiblePage)
        $("#NextSlide").children().prop('disabled',true);
}