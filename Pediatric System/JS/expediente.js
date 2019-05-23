
$(document).ready(function () {
    $(".step2").hide();
    $(".step3").hide();
    $(".step4").hide();

    $(".boxSave").hide();
});

function ocultarStep1() {
    $(".step1").hide();
    $(".step2").show();

    $(".progress-bar").addClass("progress-bar-50");
}

function ocultarStep2() {
    $(".step1").hide();
    $(".step2").hide();
    $(".step3").show();

    $(".progress-bar").addClass("progress-bar-75");
}

function ocultarStep3() {
    $(".step1").hide();
    $(".step2").hide();
    $(".step3").hide();
    $(".step4").show();

    $(".progress-bar").addClass("progress-bar-100");
    $(".boxSave").show();
}

function mostrarStep1() {
    $(".step1").show();
    $(".step2").hide();
    $(".step3").hide();
    $(".step4").show();

    $(".progress-bar").removeClass("progress-bar-100");
    $(".progress-bar").removeClass("progress-bar-75");
    $(".progress-bar").removeClass("progress-bar-50");

    $(".boxSave").hide();
}