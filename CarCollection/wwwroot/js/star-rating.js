$(document).ready(function () {
    // #################################################################################################################################################################################
    // NOTE: This can be done more efficiently and to scale by using an each() loop on the $('.fa-star'), however since its a rating system that was made last second this is hardcoded.
    // #################################################################################################################################################################################
    var rating = $('#rating').val();
    switch (rating) {
        case '1':
            set1Star();
            break;
        case '2':
            set2Star();
            break;
        case '3':
            set3Star();
            break;
        case '4':
            set4Star();
            break;
        case '5':
            set5Star();
            break;
        default:
            set0Star();
    }
    // ############################################################################################################################################################
    // NOTE: This can be done to scale by using an each() loop on the $('.fa-star'), however since its a rating system that was made last second this is hardcoded.
    // ############################################################################################################################################################
    // Star 1 ONCLICK
    $('#star1').click(function (e) {
        $('#rating').val(1);
        set1Star();
    });
   // Star 2 ONCLICK
    $('#star2').click(function (e) {
        $('#rating').val(2);
        set2Star();
    });
   // Star 3 ONCLICK
    $('#star3').click(function (e) {
        $('#rating').val(3);
        set3Star();
    });
   // Star 4 ONCLICK
    $('#star4').click(function (e) {
        $('#rating').val(4);
        set4Star();
    });
   // Star 5 ONCLICK
    $('#star5').click(function (e) {
        $('#rating').val(5);
        set5Star();
    });
    // Set Functions
    function set0Star() {
        $('#star1').css('color', 'black');
        $('#star2').css('color', 'black');
        $('#star3').css('color', 'black');
        $('#star4').css('color', 'black');
        $('#star5').css('color', 'black');
    }
    function set1Star() {
        $('#star1').css('color', 'gold');
        $('#star2').css('color', 'black');
        $('#star3').css('color', 'black');
        $('#star4').css('color', 'black');
        $('#star5').css('color', 'black');
    }
    function set2Star() {
        $('#star1').css('color', 'gold');
        $('#star2').css('color', 'gold');
        $('#star3').css('color', 'black');
        $('#star4').css('color', 'black');
        $('#star5').css('color', 'black');
    }
    function set3Star() {
        $('#star1').css('color', 'gold');
        $('#star2').css('color', 'gold');
        $('#star3').css('color', 'gold');
        $('#star4').css('color', 'black');
        $('#star5').css('color', 'black');
    }
    function set4Star() {
        $('#star1').css('color', 'gold');
        $('#star2').css('color', 'gold');
        $('#star3').css('color', 'gold');
        $('#star4').css('color', 'gold');
        $('#star5').css('color', 'black');
    }
    function set5Star() {
        $('#star1').css('color', 'gold');
        $('#star2').css('color', 'gold');
        $('#star3').css('color', 'gold');
        $('#star4').css('color', 'gold');
        $('#star5').css('color', 'gold');
    }
});