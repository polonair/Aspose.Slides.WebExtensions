const entranceBouncePath = anime.path('#entranceBouncePath');
const exitBouncePath = anime.path('#exitBouncePath');
const entranceSpiralPath = anime.path('#entranceSpiralPath');
const exitSpiralPath = anime.path('#exitSpiralPath');
const entranceCenterRevolvePath = anime.path('#entranceCenterRevolvePath');
const exitCenterRevolvePath = anime.path('#exitCenterRevolvePath');
const entranceCurveUpDownPath = anime.path('#entranceCurveUpDownPath');
const exitCurveUpDownPath = anime.path('#exitCurveUpDownPath');

function GetAnimationEffect(type, subtype, shapeId, duration, delay) {
    switch (type)    {
        case 'EntranceAppear':
            return new EntranceAppearEffect(shapeId, duration, delay, subtype);
        case 'ExitAppear':
            return new ExitAppearEffect(shapeId, duration, delay, subtype);
        case 'EntranceFade':
            return new EntranceFadeEffect(shapeId, duration, delay, subtype);
        case 'ExitFade':
            return new ExitFadeEffect(shapeId, duration, delay, subtype);
        case 'EntranceFly':
            return new EntranceFlyEffect(shapeId, duration, delay, subtype);
        case 'ExitFly':
            return new ExitFlyEffect(shapeId, duration, delay, subtype);
        case 'EntranceAscend':
            return new EntranceAscendDescendEffect(shapeId, duration, delay, 'EntranceAscend');
        case 'EntranceDescend':
            return new EntranceAscendDescendEffect(shapeId, duration, delay, 'EntranceDescend');
        case 'ExitAscend':
            return new ExitAscendDescendEffect(shapeId, duration, delay, 'ExitAscend');
        case 'ExitDescend':
            return new ExitAscendDescendEffect(shapeId, duration, delay, 'ExitDescend');
        case 'EntranceSplit':
            return new EntranceSplitEffect(shapeId, duration, delay, subtype);
        case 'ExitSplit':
            return new ExitSplitEffect(shapeId, duration, delay, subtype);
        case 'EntranceWheel':
            return new EntranceWheelEffect(shapeId, duration, delay, subtype);
        case 'ExitWheel':
            return new ExitWheelEffect(shapeId, duration, delay, subtype);
        case 'EntranceRandomBars':
            return new EntranceRandomBarsEffect(shapeId, duration, delay, subtype);
        case 'ExitRandomBars':
            return new ExitRandomBarsEffect(shapeId, duration, delay, subtype);
        case 'EntranceCircle':
            return new EntranceCircleEffect(shapeId, duration, delay, subtype);
        case 'ExitCircle':
            return new ExitCircleEffect(shapeId, duration, delay, subtype);        
        case 'EntranceBox':
            return new EntranceBoxEffect(shapeId, duration, delay, subtype);
        case 'ExitBox':
            return new ExitBoxEffect(shapeId, duration, delay, subtype);
        case 'EntranceDiamond':
            return new EntranceDiamondEffect(shapeId, duration, delay, subtype);
        case 'ExitDiamond':
            return new ExitDiamondEffect(shapeId, duration, delay, subtype);
        case 'EntrancePlus':
            return new EntrancePlusEffect(shapeId, duration, delay, subtype);
        case 'ExitPlus':
            return new ExitPlusEffect(shapeId, duration, delay, subtype);
        case 'EntranceBlinds':
            return new EntranceBlindsEffect(shapeId, duration, delay, subtype);
        case 'ExitBlinds':
            return new ExitBlindsEffect(shapeId, duration, delay, subtype);
        case 'EntranceWipe':
            return new EntranceWipeEffect(shapeId, duration, delay, subtype);
        case 'ExitWipe':
            return new ExitWipeEffect(shapeId, duration, delay, subtype);
        case 'EntranceWedge':
            return new EntranceWedgeEffect(shapeId, duration, delay, subtype);
        case 'ExitWedge':
            return new ExitWedgeEffect(shapeId, duration, delay, subtype);
        case 'EntranceDissolve':
            return new EntranceDissolveEffect(shapeId, duration, delay, subtype);
        case 'ExitDissolve':
            return new ExitDissolveEffect(shapeId, duration, delay, subtype);
        case 'EntrancePeek':
            return new EntrancePeekEffect(shapeId, duration, delay, subtype);
        case 'ExitPeek':
            return new ExitPeekEffect(shapeId, duration, delay, subtype);
        case 'EntranceStrips':
            return new EntranceStripsEffect(shapeId, duration, delay, subtype);
        case 'ExitStrips':
            return new ExitStripsEffect(shapeId, duration, delay, subtype);
        case 'EntranceFadedSwivel':
            return new EntranceFadedSwivelEffect(shapeId, duration, delay, subtype);
        case 'ExitFadedSwivel':
            return new ExitFadedSwivelEffect(shapeId, duration, delay, subtype);
        case 'EntranceFadedZoom':
            return new EntranceFadedZoomEffect(shapeId, duration, delay, subtype);
        case 'ExitFadedZoom':
            return new ExitFadedZoomEffect(shapeId, duration, delay, subtype);
        case 'EntranceExpand':
            return new EntranceExpandEffect(shapeId, duration, delay, subtype);
        case 'ExitExpand':
            return new ExitExpandEffect(shapeId, duration, delay, subtype);
        case 'EntranceZoom':
            return new EntranceZoomEffect(shapeId, duration, delay, subtype);
        case 'ExitZoom':
            return new ExitZoomEffect(shapeId, duration, delay, subtype);
        case 'EntranceRiseUp':
            return new EntranceRiseUpEffect(shapeId, duration, delay, subtype);
        case 'ExitRiseUp':
            return new ExitRiseUpEffect(shapeId, duration, delay, subtype);
        case 'EntranceCompress':
            return new EntranceCompressEffect(shapeId, duration, delay, subtype);
        case 'ExitCompress':
            return new ExitCompressEffect(shapeId, duration, delay, subtype);
        case 'EntranceSpinner':
            return new EntranceSpinnerEffect(shapeId, duration, delay, subtype);
        case 'ExitSpinner':
            return new ExitSpinnerEffect(shapeId, duration, delay, subtype);
        case 'EntranceGrowAndTurn':
            return new EntranceGrowAndTurnEffect(shapeId, duration, delay, subtype);
        case 'ExitGrowAndTurn':
            return new ExitGrowAndTurnEffect(shapeId, duration, delay, subtype);
        case 'EntrancePinwheel':
            return new EntrancePinwheelEffect(shapeId, duration, delay, subtype);
        case 'ExitPinwheel':
            return new ExitPinwheelEffect(shapeId, duration, delay, subtype);
        case 'EntranceCredits':
            return new EntranceCreditsEffect(shapeId, duration, delay, subtype);
        case 'ExitCredits':
            return new ExitCreditsEffect(shapeId, duration, delay, subtype);
        case 'EntranceSwivel':
            return new EntranceSwivelEffect(shapeId, duration, delay, subtype);
        case 'ExitSwivel':
            return new ExitSwivelEffect(shapeId, duration, delay, subtype);
        case 'EntranceFloat':
            return new EntranceFloatEffect(shapeId, duration, delay, subtype);
        case 'ExitFloat':
            return new ExitFloatEffect(shapeId, duration, delay, subtype);
        case 'EntranceBoomerang':
            return new EntranceBoomerangEffect(shapeId, duration, delay, subtype);
        case 'ExitBoomerang':
            return new ExitBoomerangEffect(shapeId, duration, delay, subtype);
        case 'EntranceWhip':
            return new EntranceWhipEffect(shapeId, duration, delay, subtype);
        case 'ExitWhip':
            return new ExitWhipEffect(shapeId, duration, delay, subtype);
        case 'EntranceSwish':
            return new EntranceSwishEffect(shapeId, duration, delay, subtype);
        case 'ExitSwish':
            return new ExitSwishEffect(shapeId, duration, delay, subtype);
        case 'EntranceBounce':
            return new EntranceBounceEffect(shapeId, duration, delay, subtype);
        case 'ExitBounce':
            return new ExitBounceEffect(shapeId, duration, delay, subtype);
        case 'EntranceSpiral':
            return new EntranceSpiralEffect(shapeId, duration, delay, subtype);
        case 'ExitSpiral':
            return new ExitSpiralEffect(shapeId, duration, delay, subtype);
        case 'EntranceCenterRevolve':
            return new EntranceCenterRevolveEffect(shapeId, duration, delay, subtype);
        case 'ExitCenterRevolve':
            return new ExitCenterRevolveEffect(shapeId, duration, delay, subtype);
        case 'EntranceCurveUpDown':
            return new EntranceCurveUpDownEffect(shapeId, duration, delay, subtype);
        case 'ExitCurveUpDown':
            return new ExitCurveUpDownEffect(shapeId, duration, delay, subtype);
            
        default:
            return new EmptyEffect(shapeId, duration, delay, type);
    }
}

class Effect {
    
    constructor(shapeId, duration, delay, subtype) {
        this.shapeId = shapeId;
        this.duration = duration * 1000;
        this.delay = delay * 1000;
        this.subtype = subtype;
        
        this.shapeParams = { left: parseInt($(this.shapeId).css('left').replace('px', '')), 
                             top: parseInt($(this.shapeId).css('top').replace('px', '')),
                             width: parseInt($(this.shapeId).css('width').replace('px', '')),
                             height: parseInt($(this.shapeId).css('height').replace('px', '')),
                             opacity: parseInt($(this.shapeId).css('opacity'))
                           };
    }
    
    Prepare() { }
    Play() { this.effectTimeline.play(); }
    Pause() { this.effectTimeline.pause(); }
    Restart() { this.effectTimeline.restart(); }
    Finish() { 
        this.Restore(); 
        $(this.shapeId.replace(' > #', '') + '-clip').empty(); 
    }
    Restore() {
        
        $(this.shapeId).css('left', this.shapeParams.left + 'px');
        $(this.shapeId).css('top', this.shapeParams.top + 'px');
        $(this.shapeId).css('width', this.shapeParams.width + 'px');
        $(this.shapeId).css('height', this.shapeParams.height + 'px');
        $(this.shapeId).css('opacity', this.shapeParams.opacity);
        
        $(this.shapeId).css({'transform': ''});
        $(this.shapeId).css('clip-path', '');
        $(this.shapeId).show();
    }
}

class EntranceAppearEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        $(this.shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            complete: function(anim) {
                $(shapeId).show();
            }
        });
    
        this.effectTimeline.add({
            duration: this.delay,
            delay: this.delay
        });
    }
}

class ExitAppearEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            complete: function(anim) {
                $(shapeId).hide();
            }
        });
    
        this.effectTimeline.add({
            duration: this.delay,
            delay: this.delay
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}


class EntranceFadeEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1
        });
    }
}

class ExitFadeEffect extends Effect {
    
    Prepare() {
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear'
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceFlyEffect extends Effect {
    
    Prepare() {
        
        var translate = GetFlyEffectTranslate(this.shapeParams, this.subtype);
        $(this.shapeId).css('transform', 'translateX(' + translate.x + 'px) translateY(' + translate.y + 'px)');
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear'
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            translateX: 0,
            translateY: 0
        });
    }
}

class ExitFlyEffect extends Effect {
    
    Prepare() {
        
        var translate = GetFlyEffectTranslate(this.shapeParams, this.subtype);
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear'
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            translateX: translate.x,
            translateY: translate.y
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceAscendDescendEffect extends Effect {
    
    Prepare() {
        
        var shapeId = this.shapeId;
        var translate = 60;
        if (this.subtype == 'EntranceAscend')
            translate = -translate;
        
        $(shapeId).css('transform', 'translateY(' + translate + 'px)');
        $(shapeId).css('opacity', '0');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            translateY: 0,
            opacity: 1
        });
    }
}

class ExitAscendDescendEffect extends Effect {
    
    Prepare() {
        
        var translate = 60;
        if (this.subtype == 'ExitAscend')
            translate = -translate;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear'
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            translateY: translate,
            opacity: 0
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceSplitEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).hide();

        if (this.effectTimeline == null) {                
            var stepsCount = 30;
            var polys = GenerateSplitPolygons(stepsCount, this.shapeParams.width, this.shapeParams.height, this.subtype.includes("Horizontal"), this.subtype.includes("Out"));
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, polys, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitSplitEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 30;
            var polys = GenerateSplitPolygons(stepsCount, this.shapeParams.width, this.shapeParams.height, this.subtype.includes("Horizontal"), !this.subtype.includes("Out"));
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, true);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();        
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceWheelEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 180;
            var wheelType = this.subtype == 'Wheel1' ? 'Wheel' : this.subtype;
            var polys = GenerateWheelSectors(wheelType, stepsCount, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, polys, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitWheelEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 180;
            var wheelType = this.subtype == 'Wheel1' ? 'Wheel' : this.subtype;
            var polys = GenerateWheelSectors(wheelType, stepsCount, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, false);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceRandomBarsEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var bars = GenerateBars(this.subtype == 'Vertical', this.shapeParams.width, this.shapeParams.height, 6, 30, 4);
            ShuffleArray(bars);
            this.effectTimeline = AnimateRandomBarsForShapes(this.shapeId, bars, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitRandomBarsEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var bars = GenerateBars(this.subtype == 'Vertical', this.shapeParams.width, this.shapeParams.height, 6, 30, 4);
            ShuffleArray(bars);
            this.effectTimeline = AnimateRandomBarsForShapesExit(this.shapeId, bars, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceCircleEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var rings = GenerateRings(stepsCount, this.shapeParams.width, this.shapeParams.height, this.subtype == 'Out');
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, rings, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitCircleEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var polys = GenerateRings(stepsCount, this.shapeParams.width, this.shapeParams.height, this.subtype == 'In');
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, false);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceBoxEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var polys = GenerateShapePolygons(stepsCount, this.subtype == 'Out' ? 'ZoomIn' : 'ZoomOut', this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, polys, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitBoxEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var polys = GenerateShapePolygons(stepsCount, this.subtype == 'Out' ? 'ZoomIn' : 'ZoomOut', this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, true);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceDiamondEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var polys = GenerateShapePolygons(stepsCount, 'Diamond' + this.subtype, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, polys, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitDiamondEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var polys = GenerateShapePolygons(stepsCount, 'Diamond' + this.subtype, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, true);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntrancePlusEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var polys = GenerateShapePolygons(stepsCount, 'Plus' + this.subtype, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, polys, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitPlusEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var polys = GenerateShapePolygons(stepsCount, 'Plus' + this.subtype, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, true);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceBlindsEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 30;
            var polys = GenerateBlindsPolygons(stepsCount, this.shapeParams.width, this.shapeParams.height, this.subtype == 'Horizontal');
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, polys, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitBlindsEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 30;
            var polys = GenerateBlindsPolygons(stepsCount, this.shapeParams.width, this.shapeParams.height, this.subtype == 'Horizontal');
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, true);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceWipeEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 40;
            var direction = this.subtype;
            if (direction == 'Bottom')
                direction = 'Up';
            if (direction == 'Top')
                direction = 'Down';
            var polys = GenerateWipePolygons(stepsCount, direction, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, polys, this.duration, this.delay, false);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitWipeEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 40;
            var direction = this.subtype;
            if (direction == 'Bottom')
                direction = 'Up';
            if (direction == 'Top')
                direction = 'Down';
            var polys = GenerateWipePolygons(stepsCount, direction, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, true);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceWedgeEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var sectors = GenerateWheelSectors('Wedge', stepsCount, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, sectors, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitWedgeEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 150;
            var sectors = GenerateWheelSectors('Wedge', stepsCount, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, sectors, this.duration, this.delay, false);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceDissolveEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var tiles = GenerateDissolvePolygons(this.shapeParams.width, this.shapeParams.height, 32, 24);
            ShuffleArray(tiles);
            this.effectTimeline = AnimateDissolveForShapes(30, this.shapeId, tiles, this.duration, this.delay);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitDissolveEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var tiles = GenerateDissolvePolygons(this.shapeParams.width, this.shapeParams.height, 32, 24);
            ShuffleArray(tiles);
            this.effectTimeline = AnimateDissolveForShapesExit(30, this.shapeId, tiles, this.duration, this.delay, false);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntrancePeekEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var stepsCount = 80;
            var direction = this.subtype;
            if (direction == 'Bottom')
                direction = 'Down';
            if (direction == 'Top')
                direction = 'Up';
            var polys = GenerateWipePolygons(stepsCount, direction, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePeekForShape(this.shapeId, polys, this.duration, this.delay, this.subtype);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitPeekEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var stepsCount = 80;
            var direction = this.subtype;
            if (direction == 'Bottom')
                direction = 'Up';
            if (direction == 'Top')
                direction = 'Down';
            if (direction == 'Left')
                direction = 'Right';
            else if (direction == 'Right')
                direction = 'Left';
            var polys = GenerateWipePolygons(stepsCount, direction, this.shapeParams.width, this.shapeParams.height);
            this.effectTimeline = AnimatePeekForShapeExit(this.shapeId, polys, this.duration, this.delay, this.subtype, false);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceStripsEffect extends Effect {
    
    Prepare() {
                
        $(this.shapeId).hide();
        
        if (this.effectTimeline == null) {
            var polys = GenerateStripsPolygons(this.shapeParams.width, this.shapeParams.height, 15, this.subtype);
            this.effectTimeline = AnimatePolygonsForShape(this.shapeId, polys, this.duration, this.delay, true);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class ExitStripsEffect extends Effect {
    
    Prepare() {
        
        $(this.shapeId).show();
        
        if (this.effectTimeline == null) {
            var polys = GenerateStripsPolygons(this.shapeParams.width, this.shapeParams.height, 15, this.subtype);
            this.effectTimeline = AnimatePolygonsForShapeExit(this.shapeId, polys, this.duration, this.delay, true, true);
        }
        
        clipContentCache[this.effectTimeline.id] = "";
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
    
    Finish() {
        $(this.shapeId).hide();
        $(this.shapeId.replace(' > #', '') + '-clip').empty();
    }
}

class EntranceFadedSwivelEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'rotateY(' + 180 + 'deg)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            rotateY: [0, 180, 0]
        });
    }
}

class ExitFadedSwivelEffect extends Effect {
    
    Prepare() {
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear'
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            rotateY: [180, 0, 180]
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceExpandEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'scaleX(' + 0.7 + ')');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            scaleX: 1
        });
    }
}

class ExitExpandEffect extends Effect {
    
    Prepare() {
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear'
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            scaleX: 0.7
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceFadedZoomEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'scale(' + 0.1 + ')');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            scale: 1
        });
    }
}

class ExitFadedZoomEffect extends Effect {
    
    Prepare() {
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear'
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            scale: 0.1
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceZoomEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('transform', 'scale(' + 0.05 + ')');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            scale: 1
        });
    }
}

class ExitZoomEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            scale: 0.05
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceRiseUpEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        var riseDistance = frameHeight - this.shapeParams.top + 100;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'translateY(' + riseDistance + 'px)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'easeInOutBack',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            translateY: 0
        });
    }
}

class ExitRiseUpEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        var riseDistance = frameHeight - this.shapeParams.top + 100;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'easeInOutBack',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            translateY: riseDistance
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}


class EntranceCompressEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'scaleX(' + 2 + ')');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'easeInCubic',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            scaleX: 1
        });
    }
}

class ExitCompressEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            scaleX: 2
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceSpinnerEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'scale(' + 0.2 + ') rotateZ(' + 180 + 'deg)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'easeOutCubic',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            scale: 1,
            rotateZ: -360
        });
    }
}

class ExitSpinnerEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        var riseDistance = frameHeight - this.shapeParams.top + 100;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'easeInCubic',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            scale: 0.2,
            rotateZ: 360
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceGrowAndTurnEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'scale(' + 0.2 + ') rotateZ(' + 90 + 'deg)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            scale: 1,
            rotateZ: 0
        });
    }
}

class ExitGrowAndTurnEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        var riseDistance = frameHeight - this.shapeParams.top + 100;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            scale: 0.2,
            rotateZ: 90
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntrancePinwheelEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'scale(' + 0.1 + ') rotateZ(' + 0 + 'deg)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            scale: 1,
            rotateZ: -720
        });
    }
}

class ExitPinwheelEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        var riseDistance = frameHeight - this.shapeParams.top + 100;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'easeInCubic',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            scale: 0.1,
            rotateZ: 720
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceCreditsEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        var lowPosition = frameHeight - this.shapeParams.top + this.shapeParams.height;
        var highPosition = -this.shapeParams.top - 2.5 * this.shapeParams.height;
        $(shapeId).css('transform', 'translateY(' + lowPosition + 'px)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            translateY: highPosition
        });
    }
    
    Finish() {
        $(this.shapeId).hide();
    }
}

class ExitCreditsEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        var lowPosition = frameHeight - this.shapeParams.top + 2.5 * this.shapeParams.height;
        var highPosition = -this.shapeParams.top - 2 * this.shapeParams.height;
        $(shapeId).css('transform', 'translateY(' + highPosition + 'px)');
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            translateY: lowPosition
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceSwivelEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('transform', 'rotateY(' + -90 + 'deg)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            rotateY: 360
        });
    }
}

class ExitSwivelEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            rotateY: -450
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceFloatEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'translateX(' + 400 + 'px) translateY(' + -300 + 'px) rotateZ(' + -90 + 'deg)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'easeOutBack',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 1,
            translateX: 0,
            translateY: 0,
            rotateZ: 0
        });
    }
}

class ExitFloatEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'easeInBack',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay,
            opacity: 0,
            translateX: 400,
            translateY: -300,
            rotateZ: -90
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceBoomerangEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'translateX(' + 300 + 'px) translateY(' + -150 + 'px) rotateZ(' + -90 + 'deg) scaleX(' + 1.2 + ')');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
        
        this.effectTimeline.add({
            duration: this.duration / 2,
            delay: this.delay,
            opacity: 0.7,
            translateX: [300, 0],
            translateY: [-150, 50],
            rotateZ: [-90, 0],
            scaleX: [1.2, 0.1]
        });
        
        this.effectTimeline.add({
            duration: this.duration / 2,
            delay: this.delay,
            opacity: 1,
            translateX: 0,
            translateY: 0,
            rotateZ: 0,
            scaleX: 1
        });
    }
}

class ExitBoomerangEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration / 2,
            delay: this.delay,
            opacity: 0.7,
            translateX: 0,
            translateY: 50,
            rotateZ: 0,
            scaleX: 0.1
        });
        
        this.effectTimeline.add({
            duration: this.duration / 2,
            delay: this.delay,
            opacity: 0,
            translateX: 300,
            translateY: -150,
            rotateZ: -90,
            scaleX: 1.2
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceWhipEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0');
        $(shapeId).css('transform', 'translateX(' + 20 + 'px) scale(' + 0.2 + ')');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
        
        this.effectTimeline.add({
            duration: this.duration / 2,
            delay: this.delay,
            opacity: 0.7,
            translateX: [20, 80],
            scale: [0.2, 1.2]
        });
        
        this.effectTimeline.add({
            duration: this.duration / 2,
            delay: this.delay,
            opacity: 1,
            translateX: 0,
            scale: 1
        });
    }
}

class ExitWhipEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration / 2,
            delay: this.delay,
            opacity: 0.7,
            translateX: 80,
            scale: 1.2
        });
        
        this.effectTimeline.add({
            duration: this.duration / 2,
            delay: this.delay,
            opacity: 0,
            translateX: 20,
            scale: 0.2
        });
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceSwishEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('transform', 'translateY(' + (-this.shapeParams.top - 1.5 * this.shapeParams.height) + 'px) rotateZ(' + -30 + 'deg)');
        $(shapeId).hide();
        
        this.effectTimeline = anime.timeline({
            targets: shapeId,
            autoplay: false,
            easing: 'linear',
            begin: function(anim) {
                $(shapeId).show();
            },
        });
        
        this.effectTimeline.add({
            duration: this.duration / 2 * 3,
            delay: this.delay,
            translateX: 0,
            translateY: -20,
        });
        
        this.effectTimeline.add({
            duration: this.duration / 3,
            delay: this.delay,
            rotateZ: 15,
            translateX: 40,
            translateY: -40,
        });
        
        this.effectTimeline.add({
            duration: this.duration / 3,
            delay: this.delay,
            rotateZ: 0,
            translateX: 0,
            translateY: 0,
        });
    }
}

class ExitSwishEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear',
            complete: function(anim) {
                $(shapeId).hide();
            },
        });
    
        this.effectTimeline.add({
            duration: this.duration / 3,
            delay: this.delay,
            rotateZ: 30,
            translateX: 50,
            translateY: 75
        });
        
        this.effectTimeline.add({
            duration: this.duration / 3 * 2,
            delay: this.delay,
            rotateZ: 25,
            translateX: 0.5 * (frameHeight - this.shapeParams.top + 0.5 * this.shapeParams.height),
            translateY: frameHeight - this.shapeParams.top + 0.5 * this.shapeParams.height
        });
        
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceBounceEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0.0');
        
        if (this.effectTimeline == null) {
            var entranceBouncePath = anime.path('#entranceBouncePath');
            
            this.effectTimeline = anime.timeline({
                targets: shapeId,
                easing: 'easeInOutQuart',
                autoplay: false,
                duration: this.duration,
                delay: this.delay,
            });
            
            this.effectTimeline.add({
                duration: this.duration,
                opacity: 1,
                translateX: entranceBouncePath('x'),
                translateY: entranceBouncePath('y')
            });
        }
    }
}

class ExitBounceEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        if (this.effectTimeline == null) {            
            var exitBouncePath = anime.path('#exitBouncePath');
                
            this.effectTimeline = anime.timeline({
                targets: shapeId,
                easing: 'easeInQuint',
                autoplay: false,
                duration: this.duration,
                delay: this.delay
            });
            
            this.effectTimeline.add({
                duration: this.duration,
                opacity: 0,
                translateX: exitBouncePath('x'),
                translateY: exitBouncePath('y')
            });
        }
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceSpiralEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0.0');
        $(shapeId).css('transform', 'scale(' + 0.1 + ')');
        
        if (this.effectTimeline == null) {
            var entranceSpiralPath = anime.path('#entranceSpiralPath');
            
            this.effectTimeline = anime.timeline({
                targets: shapeId,
                easing: 'linear',
                autoplay: false,
                duration: this.duration,
                delay: this.delay,
            });
            
            this.effectTimeline.add({
                duration: this.duration,
                opacity: 1,
                scale: 1,
                translateX: entranceSpiralPath('x'),
                translateY: entranceSpiralPath('y')
            });
        }
    }
}

class ExitSpiralEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        if (this.effectTimeline == null) {            
            var exitSpiralPath = anime.path('#exitSpiralPath');
                
            this.effectTimeline = anime.timeline({
                targets: shapeId,
                easing: 'linear',
                autoplay: false,
                duration: this.duration,
                delay: this.delay
            });
            
            this.effectTimeline.add({
                duration: this.duration,
                opacity: 0,
                scale: 0.9,
                translateX: exitSpiralPath('x'),
                translateY: exitSpiralPath('y')
            });
        }
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceCenterRevolveEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0.0');
        
        if (this.effectTimeline == null) {
            var entranceCenterRevolvePath = anime.path('#entranceCenterRevolvePath');
            
            this.effectTimeline = anime.timeline({
                targets: shapeId,
                easing: 'linear',
                autoplay: false,
                duration: this.duration,
                delay: this.delay,
            });
            
            this.effectTimeline.add({
                duration: this.duration / 10,
                opacity: 1,
            });
            
            this.effectTimeline.add({
                duration: this.duration,
                translateX: entranceCenterRevolvePath('x'),
                translateY: entranceCenterRevolvePath('y')
            });
        }
    }
}

class ExitCenterRevolveEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        if (this.effectTimeline == null) {            
            var exitCenterRevolvePath = anime.path('#exitCenterRevolvePath');
                
            this.effectTimeline = anime.timeline({
                targets: shapeId,
                easing: 'linear',
                autoplay: false,
                duration: this.duration,
                delay: this.delay
            });
            
            this.effectTimeline.add({
                duration: this.duration,
                translateX: exitCenterRevolvePath('x'),
                translateY: exitCenterRevolvePath('y')
            });
            
            this.effectTimeline.add({
                duration: this.duration / 10,
                opacity: 0,
            });
        }
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}

class EntranceCurveUpDownEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        $(shapeId).css('opacity', '0.0');
        $(shapeId).css('transform', 'scale(' + 1.7 + ')');
        
        if (this.effectTimeline == null) {
            var entranceCurveUpDownPath = anime.path('#entranceCurveUpDownPath');
            
            this.effectTimeline = anime.timeline({
                targets: shapeId,
                easing: 'linear',
                autoplay: false,
                duration: this.duration,
                delay: this.delay,
            });
            
            this.effectTimeline.add({
                duration: this.duration,
                opacity: 1,
                scale: 1,
                translateX: entranceCurveUpDownPath('x'),
                translateY: entranceCurveUpDownPath('y')
            });
        }
    }
}

class ExitCurveUpDownEffect extends Effect {
    
    Prepare() {
        var shapeId = this.shapeId;
        
        if (this.effectTimeline == null) {            
            var exitCurveUpDownPath = anime.path('#exitCurveUpDownPath');
                
            this.effectTimeline = anime.timeline({
                targets: shapeId,
                easing: 'linear',
                autoplay: false,
                duration: this.duration,
                delay: this.delay
            });
            
            this.effectTimeline.add({
                duration: this.duration,
                opacity: 0,
                scale: 1.7,
                translateX: exitCurveUpDownPath('x'),
                translateY: exitCurveUpDownPath('y')
            });
        }
    }
    
    Finish() {
        $(this.shapeId).hide();        
    }
}


class EmptyEffect extends Effect {
    
    Prepare() {
        
        console.log(this.subtype + ' is not implemented.');
        
        this.effectTimeline = anime.timeline({
            targets: this.shapeId,
            autoplay: false,
            easing: 'linear'
        });
    
        this.effectTimeline.add({
            duration: this.duration,
            delay: this.delay
        });
    }
}

function GetFlyEffectTranslate(shapeParams, subtype) {
    
    switch (subtype) {
        case 'Left':
            return {x: - shapeParams.left - shapeParams.width - 5, y: 0};
        case 'Top':
            return {x: 0, y: - shapeParams.top - shapeParams.height - 5};
        case 'Right':
            return {x: frameWidth - shapeParams.left + 5, y: 0};
        case 'Bottom':
            return {x: 0, y: frameHeight - shapeParams.top + 5};
        case 'TopLeft':
            return {x: - shapeParams.left - shapeParams.width - 5, y: - shapeParams.top - shapeParams.height - 5};
        case 'TopRight':
            return {x: frameWidth - shapeParams.left + 5, y: - shapeParams.top - shapeParams.height - 5};
        case 'BottomLeft':
            return {x: - shapeParams.left - shapeParams.width - 5, y: frameHeight - shapeParams.top + 5};
        case 'BottomRight':
            return {x: frameWidth - shapeParams.left + 5, y: frameHeight - shapeParams.top + 5};
    }
}