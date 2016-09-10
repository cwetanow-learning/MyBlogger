var done = function () {
    $('.form-control').val('');
    $('#submit').hide();
};

$('#submit').hide();

$('.form-control').keyup(function () {
    if ($(this).val().length > 0) {
        $('#submit').show();
    } else {
        $('#submit').hide();
    }
});