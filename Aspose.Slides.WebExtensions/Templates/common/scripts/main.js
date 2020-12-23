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
    var transitionType = slide.data("transitionType");
    
    if(transitionType === "Fade") {
        Fade(slideId);
    } else {
        $(slideId).show();    
    }
}

function Fade(slideId) {
    $(slideId).fadeIn();
}

function ShowNext() {
      
    if (currentVisiblePage < maxVisiblePage) {
            
        $('#slide-' + currentVisiblePage++).hide();                        
        $('#slide-' + currentVisiblePage).show();
    }
    RedrawButtons();
}

function ShowPrev() {
      
    if (currentVisiblePage > 1) {
            
        $('#slide-' + currentVisiblePage--).hide();
        $('#slide-' + currentVisiblePage).show();
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