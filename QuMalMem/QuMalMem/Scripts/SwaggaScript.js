Array.prototype.rng = function () { return this[Math.floor(Math.random() * this.length)]; };
//var rngFromArr = ["a", "b", "c"].rng();

function randomBgColor() {
    var hue = "rgb(" + Math.floor(Math.random() * 256) + "," + Math.floor(Math.random() * 256) + "," + Math.floor(Math.random() * 256) + ")";
    $("body").css("background-color", hue).css("color", hue);
    //$("body").append("<style>.knockout {background-color:" + hue + "}</style>");
}
randomBgColor();
/*
function rngbg() {
    var num = Math.floor(Math.random() * 7);
    $("html").css("background-image", "url(/img/" + num + ".png)");
}
rngbg();

$(function () {
    'use strict';
    
    var options = {
        prefetch: true,
        cacheLength: 2,
        onStart: {
            duration: 250, // Duration of our animation
            render: function ($container) {
                // Add your CSS animation reversing class
                $container.addClass('fade-in-top');

                // Restart your animation
                smoothState.restartCSSAnimations();
            }
        },
        onReady: {
            duration: 0,
            render: function ($container, $newContent) {
                // Remove your CSS animation reversing class
                $container.removeClass('fade-in-top');

                // Inject the new content
                $container.html($newContent);

            }
        }
    },
        smoothState = $('#main').smoothState(options).data('smoothState');
});

$('#main').smoothState();

$(document).ready(function () {

});
*/