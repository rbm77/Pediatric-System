
$(document).ready(function () {
    $(".step2").hide();
    $(".step3").hide();
    $(".step4").hide();

    $(".boxSave").hide();

    $(".step1 .next").on("click", function (e) {
        e.preventDefault();
        $(".progress-bar").addClass("progress-bar-50");
        $(".step1").hide();
        $(".step2").show();
    });
});

function siguienteStep1() {
    $(".step1").hide();
    $(".step2").show();

    $(".progress-bar").addClass("progress-bar-50");
}

function anteriorStep2() {
    $(".step2").hide();
    $(".step1").show();

    $(".progress-bar").removeClass("progress-bar-50");
}

function siguienteStep2() {
    $(".step2").hide();
    $(".step3").show();

    $(".progress-bar").addClass("progress-bar-75");
}

function anteriorStep3() {
    $(".step3").hide();
    $(".step2").show();

    $(".progress-bar").removeClass("progress-bar-75");
}

function siguienteStep3() {
    $(".step3").hide();
    $(".step4").show();

    $(".progress-bar").addClass("progress-bar-100");

    $(".boxSave").show();
}

function anteriorStep4() {
    $(".step4").hide();
    $(".step3").show();

    $(".progress-bar").removeClass("progress-bar-100");

    $(".boxSave").hide();
}

$('#datepicker').datepicker({
    uiLibrary: 'bootstrap4',
    locale: 'es-es',
    format: 'dd/mm/yyyy'
});