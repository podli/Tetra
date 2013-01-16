function pageLoad() {
    $(document).ready(function () {
        $('#pollSliderButton').click(function () {
            if ($(this).css("margin-right") == "300px") {
                $('#pollSlider').animate({ "margin-right": '-=300' });
                $('#pollSliderButton').animate({ "margin-right": '-=300' });
                $('#pollSliderButton').css('background-image', 'url(images/arrowOpen.png)');

            }
            else {
                $('#pollSlider').animate({ "margin-right": '+=300' });
                $('#pollSliderButton').animate({ "margin-right": '+=300' });
                $('#pollSliderButton').css('background-image', 'url(images/arrowClose.png)');
            }


        });
    });
}