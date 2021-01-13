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
var polygonsCache = {};

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
    var direction = slide.data("transitionDirection");
    
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
    } else if(transitionType === 'Cover') {
        Cover(slideId, prevSlideId);
    } else if(transitionType === 'Wipe') {
        Wipe(slideId, prevSlideId);
    } else if(transitionType === 'RandomBar') {
        RandomBar(slideId, prevSlideId);
    } else if(transitionType === 'Flash') {
        Flash(slideId, prevSlideId);
    } else if(transitionType === 'Wheel' || transitionType === 'WheelReverse' || transitionType === 'Wedge') {
        Wheel(slideId, prevSlideId, transitionType);
    } else if(transitionType === 'Dissolve') {
        Dissolve(slideId, prevSlideId);
    } else if(transitionType === 'Circle' || transitionType === 'Diamond' || transitionType === 'Plus') {
        Shape(slideId, prevSlideId, transitionType);
    } else if(transitionType === 'Zoom') {
        Shape(slideId, prevSlideId, transitionType + direction);
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
    var direction = $(slideId).data("transitionDirection");
    
    var translateX = 0;
    var translateY = 0;
    
    switch (direction) {
        case 'Right':
            translateX = -frameWidth;
            break;
        case 'Left':
            translateX = frameWidth;
            break;
        case 'Down':
            translateY = -frameHeight;
            break;
        case 'Up':
            translateY = frameHeight;
            break;
        default:
            alert(direction);
            break;
    }
    
    $(slideId).show();
    StackSlides(prevSlideId, slideId);
    
    anime({
        targets: slideId,
        duration: 10,
        translateX: translateX,
        translateY: translateY,
        easing: 'linear',
        complete: function() {
            
            StackSlides(slideId, prevSlideId);
            
            anime({
                targets: slideId,  
                translateX: 0,
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
                translateX: -translateX,
                translateY: -translateY,
                duration: duration,
                easing: 'linear',
                complete: function() {
                    
                    anime({
                        targets: prevSlideId,  
                        translateX: 0,
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
    var direction = $(slideId).data("transitionDirection");
    
    var translateX = 0;
    var translateY = 0;
    
    switch (direction) {
        case 'Right':
            translateX = frameWidth;
            break;
        case 'Left':
            translateX = -frameWidth;
            break;
        case 'Down':
            translateY = frameHeight;
            break;
        case 'Up':
            translateY = -frameHeight;
            break;
        case 'LeftDown':
            translateX = -frameWidth;
            translateY = frameHeight;
            break;
        case 'LeftUp':
            translateX = -frameWidth;
            translateY = -frameHeight;
            break;
        case 'RightDown':
            translateX = frameWidth;
            translateY = frameHeight;
            break;
        case 'RightUp':
            translateX = frameWidth;
            translateY = -frameHeight;
            break;
        default:
            alert(direction);
            break;
    }
    
    $(slideId).show();
    StackSlides(prevSlideId, slideId);
    
    anime({
        targets: prevSlideId,  
        translateX: translateX,
        translateY: translateY,
        duration: duration,
        easing: 'linear',
        complete: function() {
            
            anime({
                targets: prevSlideId,
                duration: 10,
                translateX: 0,
                translateY: 0,
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
    var direction = $(slideId).data("transitionDirection");
    
    var translateX = 0;
    var translateY = 0;
    
    switch (direction) {
        case 'Right':
            translateX = -frameWidth;
            break;
        case 'Left':
            translateX = frameWidth;
            break;
        case 'Down':
            translateY = -frameHeight;
            break;
        case 'Up':
            translateY = frameHeight;
            break;
        case 'LeftDown':
            translateX = frameWidth;
            translateY = -frameHeight;
            break;
        case 'LeftUp':
            translateX = frameWidth;
            translateY = frameHeight;
            break;
        case 'RightDown':
            translateX = -frameWidth;
            translateY = -frameHeight;
            break;
        case 'RightUp':
            translateX = -frameWidth;
            translateY = frameHeight;
            break;
        default:
            alert(direction);
            break;
    }
    
    $(slideId).show();
    StackSlides(prevSlideId, slideId);
    
    anime({
        targets: slideId,
        duration: 10,
        translateX: translateX,
        translateY: translateY,
        easing: 'linear',
        complete: function() {
            
            StackSlides(slideId, prevSlideId);
            
            anime({
                targets: slideId,  
                translateX: 0,
                translateY: 0,
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


function RandomBar(slideId, prevSlideId) {

    var duration = GetDuration(slideId);
    var direction = $(slideId).data("transitionDirection");
    
    
    var bars = GenerateBars(direction == 'Vertical', 5, 70, 1);
    ShuffleArray(bars);

    $(slideId).css('opacity', '0.0');
    $(slideId).show();

    $('#effectsclip').empty();
    $('#svgdiv').html($('#svgdiv').html());

    StackSlides(slideId, prevSlideId);
    
    $(slideId).css('clip-path', 'url(#effectsclip)');
    
    var timeline = anime.timeline({
        targets: slideId,
        autoplay: false,
        complete: function(anim) {
            $('#effectsclip').empty();
            $('#svgdiv').html($('#svgdiv').html());
            $(slideId).css('clip-path', '');
            $(prevSlideId).hide();
            PlayTransitionEnd();
        }
    });
      
    
    var finalBarsStartIndex = timeline.id;
    var i, j, k;
    var bigSteps = 1;
    var curStepBegin = 0;
    var eachStepLengh = Math.floor(bars.length / Math.max(bigSteps - 1, 1));
    
    var bigStepOpacityBase, curMinOpacity, curMaxOpacity;
    var curStepLength, curStepBars, maxBarLength;
    
    var finalBars = [];
    
    for (i = 0; i < bigSteps; i++) {
        
        bigStepOpacityBase = (1 / bigSteps) * i;
                
        curStepLength = (i < bigSteps - 1) ? eachStepLengh : bars.length - curStepBegin;
        curStepBars = bars.slice(curStepBegin, curStepBegin + curStepLength);
        maxBarLength = Math.max.apply(Math, $.map(curStepBars, function (el) { return el.length }));
        
        for (j = 0; j < maxBarLength; j++) {
            
            var microStepBars = []
            
            for(k = 0; k < curStepBars.length; k++) {
                if (j < curStepBars[k].length)
                    microStepBars.push(curStepBars[k][j]);
            }
            
            finalBars.push(microStepBars);
            
            curMinOpacity = bigStepOpacityBase + (1 / bigSteps / maxBarLength) * j;
            curMaxOpacity = bigStepOpacityBase + (1 / bigSteps / maxBarLength) * (j + 1);
            
            timeline.add({
                duration: duration / bigSteps / maxBarLength,
                opacity: [curMinOpacity, curMaxOpacity],
                easing: 'linear',
                complete: function(anim) {
                    
                    var ii = anim.id - finalBarsStartIndex - 1;
                    var jj;
                    for (jj = 0; jj < finalBars[ii].length; jj++)
                        $('#effectsclip').append(finalBars[ii][jj]);                    
                    $('#svgdiv').html($('#svgdiv').html());
                    
                }
            });
        }
        
        curStepBegin += eachStepLengh;
    }
    
    timeline.play();
}

function Flash(slideId, prevSlideId) {
    
    var duration = GetDuration(slideId);
    
    $('#flash').show();
    StackSlides('#flash', prevSlideId);
    
    
    var timeline = anime.timeline({
        targets: slideId,
        autoplay: false,
        complete: function(anim) {
            
            $('#flash').hide();
            $(prevSlideId).hide();
            PlayTransitionEnd();
        }
    });
    
    var flashDuration = 300;
    var stepsCount = 100;
    
    var saturate = 2;
    var brightness = 3;
    var opacity = 0.4
    var contrast = 1.5;
    
    var durationStep = (duration - flashDuration) / stepsCount;
    var saturateStep = (saturate - 1) / stepsCount;
    var brightnessStep = (brightness - 1) / stepsCount;
    var contrastStep = (contrast - 1) / stepsCount;
    var opacityStep = (1 - opacity) / stepsCount
    
    timeline.add({
        duration: flashDuration,
        complete: function(anim) {
            
            $(slideId).css('opacity', opacity);
            $(slideId).css('filter', 'saturate(' + saturate + ') brightness(' + brightness + ') contrast(' + contrast + ')');
            $(slideId).show();
            StackSlides(slideId, prevSlideId);
        }
    });
    
    for(var i = 0; i < stepsCount; i++) {
        
        saturate -= saturateStep;
        brightness -= brightnessStep;
        contrast -= contrastStep;
        opacity += opacityStep;
        
        timeline.add({
            duration: durationStep,
            opacity: opacity,
            filter: 'saturate(' + saturate + ') brightness(' + brightness + ') contrast(' + contrast + ')'
        });
    }
    
    timeline.play();
}

function Dissolve(slideId, prevSlideId) {
    
    var duration = GetDuration(slideId);
    var stepsCount = 50;
    
    var tiles = GenerateDissolvePolygons();
    ShuffleArray(tiles);
    
    $(slideId).css('opacity', '0.0');
    $(slideId).show();

    $('#effectsclip').empty();
    $('#svgdiv').html($('#svgdiv').html());

    StackSlides(slideId, prevSlideId);
    
    $(slideId).css('clip-path', 'url(#effectsclip)');
    
    var timeline = anime.timeline({
        targets: slideId,
        autoplay: false,
        complete: function(anim) {
            $('#effectsclip').empty();
            $('#svgdiv').html($('#svgdiv').html());
            $(slideId).css('clip-path', '');
            $(prevSlideId).hide();
            PlayTransitionEnd();
        }
    });

    var indexBase = timeline.id;
    var opacityStep, curOpacity;
    var tilesCount = Math.ceil(tiles.length / stepsCount);
    
    curOpacity = 0;
    opacityStep = (1 - curOpacity) / stepsCount;
    
    for (var i = 0; i < stepsCount; i++) {
        
        timeline.add({
            duration: duration / stepsCount,
            opacity: [curOpacity, curOpacity + opacityStep],
            easing: 'linear',
            complete: function(anim) {
                
                var j = anim.id - indexBase - 1;
                
                for (var k = tilesCount * j; k < tilesCount * (j + 1) && k < tiles.length; k++)
                    $('#effectsclip').append(tiles[k]);
                
                $('#svgdiv').html($('#svgdiv').html());
            }
        });
        
        curOpacity += opacityStep;
    }
    
    timeline.play();
}

function Wheel(slideId, prevSlideId, wheelType) {
    
    var stepsCount = 150;
    var sectors = GenerateWheelSectors(wheelType, stepsCount);
    
    AnimatePolygons(slideId, prevSlideId, sectors);
}

function Shape(slideId, prevSlideId, shapeType) {
    
    var stepsCount = 150;
    
    var polys = [];
    if (shapeType == 'Circle')
        polys = GenerateCircles(stepsCount);
    else
        polys = GenerateShapePolygons(stepsCount, shapeType);
    
    AnimatePolygons(slideId, prevSlideId, polys);
}

function AnimatePolygons(slideId, prevSlideId, polys) {
    
    var duration = GetDuration(slideId);
    var stepsCount = polys.length;
    var curOpacity = 0.8;
    
    $(slideId).css('opacity', curOpacity);
    $(slideId).show();

    $('#effectsclip').empty();
    $('#svgdiv').html($('#svgdiv').html());

    StackSlides(slideId, prevSlideId);
    
    $(slideId).css('clip-path', 'url(#effectsclip)');
    
    var timeline = anime.timeline({
        targets: slideId,
        autoplay: false,
        complete: function(anim) {
            $('#effectsclip').empty();
            $('#svgdiv').html($('#svgdiv').html());
            $(slideId).css('clip-path', '');
            $(prevSlideId).hide();
            PlayTransitionEnd();
        }
    });

    var indexBase = timeline.id;
    var opacityStep = (1 - curOpacity) / stepsCount;
    
    for (var i = 0; i < stepsCount; i++) {
        
        timeline.add({
            duration: duration / stepsCount,
            opacity: [curOpacity, curOpacity + opacityStep],
            easing: 'linear',
            complete: function(anim) {
                
                var j = anim.id - indexBase - 1;
                $('#effectsclip').append(polys[j]);
                $('#svgdiv').html($('#svgdiv').html());
            }
        });
        
        curOpacity += opacityStep;
    }
    
    timeline.play();
}

function GenerateBars(vertical, minWidth, maxWidth, gradationWidth) {
    
    var result = polygonsCache.Bars;
    if (!result) {
        
        result = [];
        var curPosition = 0;
        var limit = vertical ? frameWidth : frameHeight;
        var widths = [];
            
        while (curPosition < limit) {
            
            var nextBarWidth = Math.floor((Math.random() * (maxWidth - minWidth)) + minWidth);
            if (curPosition + nextBarWidth > limit)
                nextBarWidth = limit - curPosition;
            
            if (nextBarWidth > 1)
                widths.push(nextBarWidth);
            
            curPosition += nextBarWidth;
        };
            
    
        var prevStart = 0;
        for(var i = 0; i < widths.length; i++) {
            
            var curBarPolygons = [];
            var center = Math.floor((widths[i] + prevStart * 2) / 2);
            
            var left = center - gradationWidth;
            var right = center;
            while (left >= prevStart || right < prevStart + widths[i]) {
                
                if (left >= prevStart)
                    curBarPolygons.push(GenerateBarPolygon(vertical, left, gradationWidth));
                if (right < prevStart + widths[i])
                    curBarPolygons.push(GenerateBarPolygon(vertical, right, gradationWidth));
                
                left -= gradationWidth;
                right += gradationWidth;
            }
            
            result.push(curBarPolygons);
            
            prevStart += widths[i];
        }
        
        polygonsCache.Bars = result;
    }
    
    return result;
}

function GenerateBarPolygon(vertical, start, width) { 
    if (vertical)
        return `<polygon points="${start},${0} ${start + width},${0} ${start + width},${frameHeight} ${start},${frameHeight}"/>`;
    else
        return `<polygon points="${0},${start} ${frameWidth},${start} ${frameWidth},${start + width} ${0},${start + width}"/>`;
}

function GenerateDissolvePolygons() {
    
    var result = polygonsCache.Dissolve;
    if (!result) {
        
        result = [];
        var xStep = frameWidth / 54;
        var yStep = frameHeight / 42;
        var eps = 0.5;
        
        for(var i = 0; i < 54; i++) {
            for(var j = 0; j < 42; j++) {
            
                var x = frameWidth / 54 * i;
                var y = frameHeight / 42 * j;
                
                result.push(`<polygon points="${x - eps},${y - eps} ${x + xStep + eps},${y - eps} ${x + xStep + eps},${y + yStep + eps} ${x - eps},${y + yStep + eps}"/>`);
            }
        }
        
        polygonsCache.Dissolve = result;
    }
        
    return result;
}

function GenerateShapePolygons(stepsCount, shapeType) {
    
    var result = polygonsCache[shapeType];
    if (!result) {
        
        result = [];
        var centerX = frameWidth / 2;
        var centerY = frameHeight / 2;
        
        var xStep = frameWidth / stepsCount / 2;
        var yStep = frameHeight / stepsCount / 2;
        if (shapeType == 'Diamond') {
            xStep *= 2;
            yStep *= 2;
        }
        
        var x, y;
        
        for(var i = 0; i < stepsCount; i++) {
            
            x = xStep * i;
            y = yStep * i;
            
            if (shapeType == 'ZoomOut') {
                x += xStep;
                y += yStep;
            }
            
            if (shapeType == 'Plus')
                result.push(`<polygon points="${0},${centerY - y} ${centerX - x},${centerY - y} ${centerX - x},${0} ${centerX + x},${0} ${centerX + x},${centerY - y} ${frameWidth},${centerY - y} ${frameWidth},${centerY + y} ${centerX + x},${centerY + y} ${centerX + x},${frameHeight} ${centerX - x},${frameHeight} ${centerX - x},${centerY + y} ${0},${centerY + y}"/>`);
            else if (shapeType == 'Diamond')
                result.push(`<polygon points="${centerX - x},${centerY} ${centerX},${centerY - y} ${centerX + x},${centerY} ${centerX},${centerY + y}"/>`);
            else if (shapeType == 'ZoomIn')
                result.push(`<polygon points="${0},${0} ${frameWidth},${0} ${frameWidth},${y} ${x},${y} ${x},${frameHeight - y} ${frameWidth - x},${frameHeight - y} ${frameWidth - x},${y} ${frameWidth},${y} ${frameWidth},${frameHeight} ${0},${frameHeight}"/>`);
            else if (shapeType == 'ZoomOut')
                result.push(`<polygon points="${centerX - x},${centerY - y} ${centerX + x},${centerY - y} ${centerX + x},${centerY + y} ${centerX - x},${centerY + y}"/>`);
        }
    
        polygonsCache[shapeType] = result;
    }
    
    return result;
}

function GenerateWheelSectors(wheelType, stepsCount) {
        
    var result = polygonsCache[wheelType];
    if (!result) {
        
        result = [];
        var angleStep = 360 / stepsCount;
        var currentAngle = 0;
        var radius = Math.max(frameWidth, frameHeight) + 10;
        var centerX = frameWidth / 2;
        var centerY = frameHeight / 2;
        var angleFix = wheelType == 'WheelReverse' ? -2 : 2;
        
        var opts = {
            cx: centerX,
            cy: centerY,
            radius: radius,
            start_angle: angleFix ,
            end_angle: wheelType == 'WheelReverse' ? -angleStep: angleStep
        };
        
        var start, end, largeArcFlag;
        
        for (var i = 0; i < stepsCount && opts.end_angle + angleFix < 362; i++) {
            
            start = PolarToCartesian(opts.cx, opts.cy, opts.radius, opts.end_angle + angleFix);
            end = PolarToCartesian(opts.cx, opts.cy, opts.radius, opts.start_angle - angleFix);
            largeArcFlag = opts.end_angle - opts.start_angle <= 180 ? "0" : "1";
            
            var pathData = [
                "M", start.x, start.y,
                "A", opts.radius, opts.radius, 0, largeArcFlag, 0, end.x, end.y,
                "L", opts.cx, opts.cy,
                "Z"
            ].join(" ");
            
            if (wheelType == 'WheelReverse') {
                opts.start_angle -= angleStep;
                opts.end_angle -= angleStep;
            }
            else {
                opts.start_angle += angleStep;
                opts.end_angle += angleStep;
            }
            
            result.push('<path d="' + pathData + '"/>');
        }
        
        if (wheelType == 'Wedge') {
            var resultRearranged = [];
            for (var i = 0; i < stepsCount / 2; i++) {
                resultRearranged.push(result[i]);
                resultRearranged.push(result[result.length - i]);
            }
            result = resultRearranged;
        }
        
        polygonsCache[wheelType] = result;    
    }
    
    return result;
}

function GenerateCircles(stepsCount) {
    
    var result = polygonsCache.Circles;
    if (!result) {
    
        result = [];
        var centerX = frameWidth / 2;
        var centerY = frameHeight / 2;
        
        var minRadius = 1;
        var maxRadius = Math.max(frameWidth, frameHeight) / 2 * 1.4142;
        var radiusStep = (maxRadius - minRadius) / stepsCount;
        var radius = minRadius;

        
        var opts = {
            cx: centerX,
            cy: centerY,
            radius: radius,
            start_angle: 0,
            end_angle: 359.999
        };
        
        for(var i = 0; i < stepsCount; i++) {
            
            start = PolarToCartesian(opts.cx, opts.cy, opts.radius, opts.end_angle);
            end = PolarToCartesian(opts.cx, opts.cy, opts.radius, opts.start_angle);
            largeArcFlag = opts.end_angle - opts.start_angle <= 180 ? "0" : "1";
            
            var pathData = [
                "M", start.x, start.y,
                "A", opts.radius, opts.radius, 0, largeArcFlag, 0, end.x, end.y,
                "L", opts.cx, opts.cy,
                "Z"
            ].join(" ");
            
            opts.radius += radiusStep;
            
            result.push('<path d="' + pathData + '"/>');
        }
        
        polygonsCache.Circles = result;
    }
    
    return result;
}

function PolarToCartesian(centerX, centerY, radius, angleInDegrees) {
    var angleInRadians = (angleInDegrees - 90) * Math.PI / 180.0;

    return {
        x: centerX + (radius * Math.cos(angleInRadians)),
        y: centerY + (radius * Math.sin(angleInRadians))
    };
}

function ShuffleArray(array) {
    var currentIndex = array.length;
    var temporaryValue, randomIndex;
    
    while (0 !== currentIndex) {
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex -= 1;
        temporaryValue = array[currentIndex];
        array[currentIndex] = array[randomIndex];
        array[randomIndex] = temporaryValue;
    }
    
    return array;
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