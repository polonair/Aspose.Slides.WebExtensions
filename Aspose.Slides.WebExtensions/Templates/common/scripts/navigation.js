@inherits RazorEngineCore.RazorEngineTemplateBase<TemplateContext<Presentation>>

@{
    Presentation contextObject = Model.Object;
    var navigationEnabled = Model.Global.Get<bool>("navigationEnabled").ToString().ToLower();
    var animateTransitions = Model.Global.Get<bool>("animateTransitions").ToString().ToLower();
    var animateShapes = Model.Global.Get<bool>("animateShapes").ToString().ToLower();
    var pagesCount = contextObject.Slides.Count;
}

var currentVisiblePage = 0;
var maxVisiblePage = @pagesCount;

$(document).ready(function(){
      
    if (@navigationEnabled)
        InitNavigation();
    
    if (!@animateTransitions)
        ShowSlide(1);
    else
        currentVisiblePage = 1;
    ChangeThumbSelection(1);
});

function InitNavigation() {
      
    if ($(".navigationArea")[0].scrollHeight <= $(".navigationArea")[0].clientHeight) {
        $(".navigationArea").css('width', '222');    
        $('.navigationArea').addClass('navigationAreaBorder');
    }
    else {
        $(".navigationArea").css('width', '');    
        $('.navigationArea').removeClass('navigationAreaBorder');
    }
    
    SetThumbnailClickHandler();
}

function RemoveThumbnailClickHandler() {
    $(".slideThumb").unbind();
}

function SetThumbnailClickHandler() {
    RemoveThumbnailClickHandler();
    $(".slideThumb").click(function(){ ShowSlide($(this).data('number')); });
}

function ShowSlide(nextVisiblePage) {
    
    if (nextVisiblePage != currentVisiblePage) {         
        ChangeThumbSelection(nextVisiblePage);
        var prevSlideId = '#slide-' + currentVisiblePage;
        var slideId = '#slide-' + nextVisiblePage;
        currentVisiblePage = nextVisiblePage;
        
        if (@animateTransitions) {
            if (@animateShapes)
                PauseAllEffects(animations);
            
            PrepareAndPlayTransition(slideId, prevSlideId);
        }
        else {
            StackSlides(slideId, prevSlideId);
            $(prevSlideId).hide();
            $(slideId).show();
            
            if (@animateShapes) {
                PauseAllEffects(prevAnimations);
                RestoreAllEffects(prevAnimations);
                AnimateShapes(slideId);
                PlayNextAnimationsForTarget('slide');
            }
        }
    }
    else {
        
        if (@animateShapes) {
            PauseAllEffects(animations);
            RestoreAllEffects(animations);
            PrepareAllEffects(animations);
            ResetAnimationIndicies();
            PlayNextAnimationsForTarget('slide');
        }
    }
}

function ChangeThumbSelection(nextVisiblePage) {
    $('.slideThumb').removeClass('navigationSelected');
    $('#slideThumb-' + nextVisiblePage).addClass('navigationSelected');
}