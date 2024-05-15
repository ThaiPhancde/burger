document.addEventListener("DOMContentLoaded", function() {
    var owl = document.getElementById('nav-top-carousel');
    
    $(owl).owlCarousel({
        margin: 10,
        autoWidth: false,
        items: 9,
        loop: false,
        autoplay: false,
        autoplayTimeout: 5000,
        nav: false,
        dots: false,
        responsive: {
            320: {
                items: 2
            },
            480: {
                items: 3
            },
            768: {
                items: 5
            },
            1024: {
                items: 9
            }
        }
    });

    document.querySelector('.actions .action.next').addEventListener('click', function() {
        $(owl).trigger('next.owl.carousel');
    });
    document.querySelector('.actions .action.prev').addEventListener('click', function() {
        $(owl).trigger('prev.owl.carousel');
    });
});
