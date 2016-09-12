$(document).ready(function () {
    $('#posts').hide();
    $('#comments').hide();
});

$('#postsToggle').click(function () {
    $('#posts').fadeToggle();
});

$('#commentsToggle').click(function () {
    $('#comments').fadeToggle();
});