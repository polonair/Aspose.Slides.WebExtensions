@model TemplateContext<Presentation>

@{
    Presentation contextObject = Model.Object;
    var navigationEnabled = Model.Global.Get<bool>("navigationEnabled").ToString().ToLower();
    var animateTransitions = Model.Global.Get<bool>("animateTransitions").ToString().ToLower();
    var pagesCount = contextObject.Slides.Count;
}

var currentVisiblePage = 1;
var maxVisiblePage = @pagesCount;

$(document).ready(function(){
      
    if (@navigationEnabled) {
        InitNavigation();
    }
    
    if (!@animateTransitions) {
        ShowSlide(1);
    }
});

function InitNavigation() {
      
    if ($(".navigationArea")[0].scrollHeight <= $(".navigationArea")[0].clientHeight) {
        $(".navigationArea").width(220);
    }
    
    $(".slideThumb").click(function(){ ShowSlide($(this).data('number')); });
}

function ShowSlide(nextVisiblePage) {
    
    PlayTransitionBegin();
    $('#slide-' + currentVisiblePage).hide();
    $('#slide-' + nextVisiblePage).show();
    ChangeThumbSelection(nextVisiblePage);
    
    currentVisiblePage = nextVisiblePage;
    PlayTransitionEnd();
}

function ChangeThumbSelection(nextVisiblePage) {
    $('.slideThumb').css('background', '');
    $('#slideThumb-' + nextVisiblePage).css('background', '#D24726');
}