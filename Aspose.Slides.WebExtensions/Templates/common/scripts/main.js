@model TemplateContext<Presentation>

@{
    Presentation contextObject = Model.Object;
    var animateTransitions = Model.Global.Get<bool>("animateTransitions").ToString().ToLower();
    var pagesCount = contextObject.Slides.Count;
    var imagesPath = Model.Global.Get<string>("imagesPath");
    var slideWidth = contextObject.SlideSize.Size.Width;
    var slideHeight = contextObject.SlideSize.Size.Height;
}


var currentVisiblePage = 1;
var maxVisiblePage = @pagesCount;
var frameWidth = @slideWidth;
var frameHeight = @slideHeight;

$(document).ready(function(){
      
    if (@animateTransitions) {
        InitTransitions();
    }
});

function InitTransitions() {
    PlayTransition('#slide-1', null);
    
    $('#PrevSlide').show();
    $('#NextSlide').show();
      
    $("#PrevSlide").click(function(){ ShowPrev(); });
    $("#NextSlide").click(function(){ ShowNext(); });
}

function PlayTransition(slideId, prevSlideId) {
    console.log('move from ' + prevSlideId + ' to ' + slideId);
    PlayTransitionBegin();

    var slide = $(slideId);
    var transitionType = slide.data('transitionType');
    
    ResetAnimationProperties();
    
    // assertions on the start of the transition:
    //   prevSlide is visible
    //   slide is hidden
    if(transitionType === 'Fade') {
        Fade(slideId, prevSlideId); 
    } else if(transitionType === 'Push') {
        Push(slideId, prevSlideId);
    } else if(transitionType === 'Pull') {
        Pull(slideId, prevSlideId);
    }else if(transitionType === 'Cover') {
        Cover(slideId, prevSlideId);
    }else if(transitionType === 'Wipe') {
        Wipe(slideId, prevSlideId);        
    } else {
        $(prevSlideId).hide();
        $(slideId).show();
        PlayTransitionEnd();
    }
}

function PlayTransitionBegin() {
    $("#PrevSlide").prop('disabled',true);
    $("#NextSlide").prop('disabled',true);    
}

function PlayTransitionEnd() {
    if(currentVisiblePage != 1) {
        $("#PrevSlide").prop('disabled',false);
    }
    
    if(currentVisiblePage != maxVisiblePage) {
        $("#NextSlide").prop('disabled',false);
    } 
}

function ResetAnimationProperties() {
    $(".slide").css("z-index", '');
    $(".slide-content").css('transform', '');
    $(".slide-content").css('position', '');
    $(".slide-content").css('top', '');
}

function Fade(slideId, prevSlideId) {
    if(prevSlideId) {
        StackSlides(slideId, prevSlideId);
    }
    
    var duration = GetDuration(slideId); 
    $(slideId).fadeIn(duration).promise().done(function(){
        $(prevSlideId).hide();
        PlayTransitionEnd();
    });
}

function Push(slideId, prevSlideId) {    
    var duration = GetDuration(slideId);
    
    $(slideId).show();
    StackSlides(prevSlideId, slideId);
    
    anime({
        targets: slideId,
        duration: 10,
        translateY: frameHeight,
        easing: 'linear',
        complete: function() {
            StackSlides(slideId, prevSlideId);
            
            anime({
                targets: slideId,  
                translateY: 0,
                duration: duration,
                easing: 'linear',
                complete: function() {
                    $(prevSlideId).hide();
                    PlayTransitionEnd();
                } 
            });
            
            anime({
                targets: prevSlideId,  
                translateY: -frameHeight,
                duration: duration,
                easing: 'linear',
                complete: function() {
                    anime({
                        targets: prevSlideId,  
                        translateY: 0,
                        duration: 10,
                        easing: 'linear'
                    });
                }
            });
        }
    });
}

function Pull(slideId, prevSlideId) {    
    var duration = GetDuration(slideId);
    
    $(slideId).show();
    StackSlides(prevSlideId, slideId);
    
    anime({
        targets: prevSlideId,  
        translateX: -frameWidth,
        duration: duration,
        easing: 'linear',
        complete: function() {
            anime({
                targets: prevSlideId,
                duration: 10,
                translateX: 0,
                easing: 'linear'
            });
        
            StackSlides(slideId, prevSlideId);
            $(prevSlideId).hide();
            PlayTransitionEnd();
        } 
    });
}

function Cover(slideId, prevSlideId) {    
    var duration = GetDuration(slideId);
    
    $(slideId).show();
    StackSlides(prevSlideId, slideId);
    
    anime({
        targets: slideId,
        duration: 10,
        translateX: frameWidth,
        easing: 'linear',
        complete: function() {
            StackSlides(slideId, prevSlideId);
                
            anime({
                targets: slideId,  
                translateX: 0,
                duration: duration,
                easing: 'linear',
                complete: function() {
                      
                    $(prevSlideId).hide();
                    PlayTransitionEnd();
                } 
            });
        }
    });
}

function Wipe(slideId, prevSlideId) {

}

function StackSlides(foreground, background) {
    $(background).css("z-index", 1);
    $(foreground).css("z-index", 2);
}

function GetDuration(slideId) {
    var transitionSpeed = $(slideId).data("transitionSpeed");
    
    var duration = 700;
    if(transitionSpeed == 'Fast') { duration = 400; } 
    else if(transitionSpeed == 'Medium') { duration = 700; } 
    else if(transitionSpeed == 'Slow') { duration = 1500; } 
    
    return duration;
}

function ShowNext() {
      
    if (currentVisiblePage < maxVisiblePage) {
        var prevSlideId = '#slide-' + currentVisiblePage++;
        var slideId = '#slide-' + currentVisiblePage;
        PlayTransition(slideId, prevSlideId);            
    }
}

function ShowPrev() {
      
    if (currentVisiblePage > 1) {
        var prevSlideId = '#slide-' + currentVisiblePage--;
        var slideId = '#slide-' + currentVisiblePage;
        PlayTransition(slideId, prevSlideId);
    }
}