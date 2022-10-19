var revApi = new Object();
var revApiMobile = new Object();
var loopStatu;
sliderOperations = function () {
    if ($('.sliderWrap').length > 0) {
        $('.sliderWrap').each(function () {
            var offSet = $(".sliderWrap").offset();
            var sliderH = $(this).children('.sliderArea').height();

            $('.sliderWrap').css('height', (sliderH));
        });
    }

    if ($('.banner').length > 0) {
        var bannerStartHeight = ($('.banner').attr('data-startHeight') ? $('.banner').attr('data-startHeight') : 555);

        revApi = $('.banner').show().revolution(
            {
                dottedOverlay: "none",
                delay: 9999999999999,
                startwidth: 1170,
                startheight: bannerStartHeight,
                hideThumbs: 200,

                dataStart: 0,

                thumbWidth: 100,
                thumbHeight: 50,
                thumbAmount: 5,

                navigationType: "none",
                navigationArrows: "none",
                navigationStyle: "none",

                touchenabled: "off",
                onHoverStop: "off",

                swipe_velocity: 0.7,
                swipe_min_touches: 1,
                swipe_max_touches: 1,
                drag_block_vertical: false,

                parallax: "mouse",
                parallaxBgFreeze: "on",
                parallaxLevels: [7, 4, 3, 2, 5, 4, 3, 2, 1, 0],

                keyboardNavigation: "on",

                navigationHAlign: "center",
                navigationVAlign: "bottom",
                navigationHOffset: 0,
                navigationVOffset: 20,

                soloArrowLeftHalign: "left",
                soloArrowLeftValign: "center",
                soloArrowLeftHOffset: 20,
                soloArrowLeftVOffset: 0,

                soloArrowRightHalign: "right",
                soloArrowRightValign: "center",
                soloArrowRightHOffset: 20,
                soloArrowRightVOffset: 0,

                shadow: 0,
                fullWidth: "on",
                fullScreen: "off",

                spinner: "off",

                stopLoop: "on",
                stopAfterLoops: -1,
                stopAtSlide: -1,

                shuffle: "off",

                autoHeight: "off",
                forceFullWidth: "off",

                hideThumbsOnMobile: "off",
                hideNavDelayOnMobile: 1500,
                hideBulletsOnMobile: "off",
                hideArrowsOnMobile: "off",
                hideThumbsUnderResolution: 0,

                hideSliderAtLimit: 0,
                hideCaptionAtLimit: 0,
                hideAllCaptionAtLilmit: 0,
                startWithSlide: 0,
                videoJsPath: "rs-plugin/videojs/",
                fullScreenOffsetContainer: "",
            });
    }

    //NOTE: start point for rev slider
    var slides = $('.banner ul').find('li'),
        totalSlides = slides.length,
        randomIndex = 1 * (totalSlides - 2);
    slides.eq(randomIndex).insertBefore(slides.eq(0));

    var timer;
    var time = 300;
    if ($('section.slider-content .sliderWrap .sliderArea .campaign-area').length > 0) {
        $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(1) .campaign,section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(1) .campaign-bottom').mouseenter(function () {
            var that = this;
            timer = setTimeout(function () {
                revApi.revshowslide(2);
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .left-radius').addClass('disabled');
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .right-radius').removeClass('disabled');
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .campaign-outer').removeClass('hover');
                $(that).parent().addClass('hover');
                if ($(that).parent().find('.campaign-bottom .bg-color').css('width') == '0px') {
                    $(that).parent().find('.campaign-bottom .bg-color').stop().animate({
                        'display': "block",
                        'width': "100%"
                    }, time);
                };
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2)').css({
                    'border-radius': '10px 0px 0px 0px'
                });
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(3)').css({
                    'border-radius': '0px 0px 0px 0px'
                });
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2) .campaign-bottom .bg-color,section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(3) .campaign-bottom .bg-color').css({
                    'width': '0%'
                });
            }, time);
        }).mouseleave(function () {
            clearTimeout(timer);
        });
    }

    if ($('section.slider-content .sliderWrap .sliderArea .campaign-area').length > 0) {
        $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2) .campaign,section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2) .campaign-bottom').mouseenter(function () {
            var that = this;
            timer = setTimeout(function () {
                revApi.revshowslide(1);
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .left-radius').removeClass('disabled');
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .right-radius').removeClass('disabled');
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .campaign-outer').removeClass('hover');
                $(that).parent().addClass('hover');
                if ($(that).parent().find('.campaign-bottom .bg-color').css('width') == '0px') {
                    $(that).parent().find('.campaign-bottom .bg-color').stop().animate({
                        'display': "block",
                        'width': "100%"
                    }, time);
                };
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(1)').css({
                    'border-radius': '0px 10px 0px 0px'
                });
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(3)').css({
                    'border-radius': '10px 0px 0px 0px'
                });
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(1) .campaign-bottom .bg-color,section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(3) .campaign-bottom .bg-color').css({
                    'width': '0%'
                });
            }, time);
        }).mouseleave(function () {
            clearTimeout(timer);
        });
    }

    if ($('section.slider-content .sliderWrap .sliderArea .campaign-area').length > 0) {
        $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(3) .campaign,section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(3) .campaign-bottom').mouseenter(function () {
            var that = this;
            timer = setTimeout(function () {
                revApi.revshowslide(3);
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .right-radius').addClass('disabled');
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .left-radius').removeClass('disabled');
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .campaign-outer').removeClass('hover');
                $(that).parent().addClass('hover');
                if ($(that).parent().find('.campaign-bottom .bg-color').css('width') == '0px') {
                    $(that).parent().find('.campaign-bottom .bg-color').stop().animate({
                        'display': "block",
                        'width': "100%"
                    }, time);
                };
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(1)').css({
                    'border-radius': '0px 0px 0px 0px'
                });
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2)').css({
                    'border-radius': '0px 10px 0px 0px'
                });
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2) .campaign').css({
                    'margin-right': '15px'
                });
                $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(1) .campaign-bottom .bg-color,section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2) .campaign-bottom .bg-color').css({
                    'width': '0%'
                });
            }, time);
        }).mouseleave(function () {
            clearTimeout(timer);
        });
    }

    // mobile
    if ($('.mobile-banner').length > 0) {
        var mobileBannerStartHeight = ($('.mobile-banner').attr('data-startHeight') ? $('.mobile-banner').attr('data-startHeight') : 500);


        revApiMobile = $('.mobile-banner').show().revolution(
            {
                dottedOverlay: "none",
                delay: 9999999999999,
                startwidth: 1170,
                //startheight: mobileBannerStartHeight,
                hideThumbs: 200,

                thumbWidth: 100,
                thumbHeight: 50,
                thumbAmount: 5,

                navigationType: "bullet",
                navigationStyle: "round",
                navigationArrows: "none",

                touchenabled: "on",
                onHoverStop: "on",

                swipe_velocity: 0.7,
                swipe_min_touches: 1,
                swipe_max_touches: 1,
                drag_block_vertical: false,

                parallax: "mouse",
                parallaxBgFreeze: "on",
                parallaxLevels: [7, 4, 3, 2, 5, 4, 3, 2, 1, 0],

                keyboardNavigation: "on",

                navigationHAlign: "center",
                navigationVAlign: "bottom",
                navigationHOffset: 0,
                navigationVOffset: 20,

                soloArrowLeftHalign: "left",
                soloArrowLeftValign: "center",
                soloArrowLeftHOffset: 20,
                soloArrowLeftVOffset: 0,

                soloArrowRightHalign: "right",
                soloArrowRightValign: "center",
                soloArrowRightHOffset: 20,
                soloArrowRightVOffset: 0,

                shadow: 0,
                fullWidth: "on",
                fullScreen: "off",

                spinner: "off",

                stopLoop: "off",
                stopAfterLoops: -1,
                stopAtSlide: -1,

                shuffle: "off",

                autoHeight: "off",
                forceFullWidth: "off",

                hideThumbsOnMobile: "on",
                hideNavDelayOnMobile: 1500,
                hideBulletsOnMobile: "off",
                hideArrowsOnMobile: "off",
                hideThumbsUnderResolution: 0,

                hideSliderAtLimit: 0,
                hideCaptionAtLimit: 0,
                hideAllCaptionAtLilmit: 0,
                startWithSlide: 0,
                videoJsPath: "rs-plugin/videojs/",
                fullScreenOffsetContainer: ""
            });

        $('.mobile-banner').parents('.mobile-sliderArea').removeClass('d-none');
    }

    //NOTE: start point for rev slider
    var mobile_slides = $('.mobile-banner ul').find('li'),
        mobile_totalSlides = mobile_slides.length,
        mobile_randomIndex = 1 * (mobile_totalSlides - 2);
    mobile_slides.eq(mobile_randomIndex).insertBefore(mobile_slides.eq(0));

};

alertOperations = function () {
    var AlertVal = getCookie("DigiturkPartnerAlert");
    if (AlertVal != "1") {
        $('.alert-content').removeClass('d-none');
    }

    $('.alert').on('close.bs.alert', function (e) {
        e.stopPropagation();
        $(this).closest('.alert')
            .animate({
                height: 'toggle',
                opacity: 'toggle'
            });

        setCookie("DigiturkPartnerAlert", "1");
    });
};

maskOperations = function () {
    if ($('.phone-mask').length > 0) {
        $('.phone-mask').inputmask({
            "mask": "(599) 999 99 99"
        });
    }
};

validateOperations = function () {
    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
        "Alanı kontrol ediniz."
    );

    if ($('.contactForm').length > 0) {
        $('.contactForm').validate({
            rules: {
                name: { required: true, regex: "^[a-zA-Z çÇşŞöÖıİüÜğĞ*]{1,50}$", maxlength: 50 },
                phone: "required"
            },
            messages: {
                name: {
                    required: "Ad Soyad alanı zorunludur.",
                    maxlength: "Ad Soyad alanı 50 karakteri geçemez.",
                    regex: "Ad Soyad alanını kontrol ediniz."
                },
                phone: "Telefon alanı zorunludur."
            }
        });
    }

    if ($('.appealForm').length > 0) {
        $('.appealForm').validate({
            rules: {
                name: { required: true, regex: "^[a-zA-Z çÇşŞöÖıİüÜğĞ*]{1,50}$", maxlength: 50 },
                phone: "required"
            },
            messages: {
                name: {
                    required: "Ad Soyad alanı zorunludur.",
                    maxlength: "Ad Soyad alanı 50 karakteri geçemez.",
                    regex: "Ad Soyad alanını kontrol ediniz."
                },
                phone: "Telefon alanı zorunludur."
            }
        });
    }

    if ($('#modalForm').length > 0) {
        $('#modalForm').validate({
            rules: {
                name: { required: true, regex: "^[a-zA-Z çÇşŞöÖıİüÜğĞ\\s]{1,50}$", maxlength: 50 },
                phone: "required"
            },
            messages: {
                name: {
                    required: "Ad Soyad alanı zorunludur.",
                    maxlength: "Ad Soyad alanı 50 karakteri geçemez.",
                    regex: "Ad Soyad alanını kontrol ediniz."
                },
                phone: "Telefon alanı zorunludur."
            }
        });
    }
};

animateOperations = function () {
    $('[data-animation]').each(function () {
        var $item = $(this);
        $item.addClass('animated');

        $item.appear(function () {
            delay = ($item.attr('data-animation-delay') ? $item.attr('data-animation-delay') : 1);

            setTimeout(function () {
                $item.addClass($item.attr('data-animation'));
                $item.addClass('animated-visible');
            }, delay);
        });
    });
};

owlCarouselOperations = function () {

    if ($('.owl-carousel.movie-slider').length > 0) {
        $('.owl-carousel.movie-slider').owlCarousel({
            items: 4,
            loop: true,
            margin: 0,
            merge: true,
            nav: true,
            dots: false,
            navText: ['<div class="btn slider-left-btn"><img src="/dosyalar/Assets/images/svg/left_arrow.svg" /></div>', '<div class="btn slider-right-btn"><img src="/dosyalar/Assets/images/svg/right_arrow.svg" /></div>'],
            responsive: {
                0: {
                    items: 1
                },
                576: {
                    items: 2
                },
                768: {
                    items: 4
                }
            }
        });
    }

    if ($('.owl-carousel.logo-slider').length > 0) {
        $('.owl-carousel.logo-slider').owlCarousel({
            items: 5,
            autoWidth: true,
            loop: true,
            margin: 10,
            nav: true,
            dots: false,
            mouseDrag: true,
            navText: ['<div class="btn slider-left-btn"><img src="/dosyalar/Assets/images/svg/arrow_left-owl.svg" /></div>', '<div class="btn slider-right-btn"><img src="/dosyalar/Assets/images/svg/arrow_right-owl.svg" /></div>']
        });
    }

    if ($('.owl-carousel.campaignAll').length > 0) {
        $('.owl-carousel.campaignAll').owlCarousel({
            items: 4,
            autoWidth: true,
            loop: true,
            margin: 15,
            nav: true,
            dots: false,
            mouseDrag: true,
            navText: ['<div class="btn slider-left-btn"><img src="/dosyalar/Assets/images/svg/arrow_left-owl.svg" /></div>', '<div class="btn slider-right-btn"><img src="/dosyalar/Assets/images/svg/arrow_right-owl.svg" /></div>']
        });
    }
};

slickSliderOperations = function () {
    $campaignCarousel = $('.campaign-carousel').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        infinite: true,
        fade: true,
        draggable: false,
        speed: 800,
        cssEase: 'linear',
        autoplay: false,
        dots: true,
        prevArrow: '<div class="btn slider-left-btn"><img src="/dosyalar/Assets/images/svg/left_arrow.svg"/></div>',
        nextArrow: '<div class="btn slider-right-btn"><img src="/dosyalar/Assets/images/svg/right_arrow.svg"/></div>',
        responsive: [
            {
                breakpoint: 769,
                settings: {
                    draggable: true,
                    dots: true,
                    arrows: true,
                    infinite: true
                }
            }
        ]
    });

    $campaignCarousel.on('beforeChange', function (event, slick, currentSlide, nextSlide) {
        var item = $('.campaign-carousel .slick-slide[index=" + nextSlide + "]');
        $('.campaign-carousel .slick-slide').removeClass('current-slide');
        item.addClass("current-slide");

        $('.campaign-carousel .slick-slide').eq(currentSlide).find('.campaign-carousel-left').removeClass('animated fadeInLeft fadeOutLeft fadeInRight fadeOutRight');
        $('.campaign-carousel .slick-slide').eq(currentSlide).find('.campaign-carousel-right ,h4,h3').removeClass('animated fadeInLeft fadeOutLeft fadeInRight fadeOutRight');
        $('.campaign-carousel .slick-slide').eq(currentSlide).find('.campaign-carousel-left').addClass('animated fadeOutLeft');
        $('.campaign-carousel .slick-slide').eq(currentSlide).find('.campaign-carousel-right ,h4,h3').addClass('animated fadeOutRight');
        $('.campaign-carousel .slick-track .slick-slide:first-child .campaign-carousel-row .campaign-carousel-left,.campaign-carousel .slick-track .slick-slide:first-child .campaign-carousel-row .campaign-carousel-right').css('opacity', '0');
    });

    $campaignCarousel.on('afterChange', function (event, slick, currentSlide, nextSlide) {
        $('.campaign-carousel .slick-slide').eq(currentSlide).find('.campaign-carousel-left').removeClass('animated fadeInLeft fadeInRight fadeOutRight fadeOutLeft');
        $('.campaign-carousel .slick-slide').eq(currentSlide).find('.campaign-carousel-right ,h4,h3').removeClass('animated fadeInLeft fadeInRight fadeOutLeft fadeOutRight');
        $('.campaign-carousel .slick-slide').eq(currentSlide).find('.campaign-carousel-left').addClass('animated fadeInLeft');
        $('.campaign-carousel .slick-slide').eq(currentSlide).find('.campaign-carousel-right ,h4,h3').addClass('animated fadeInRight');
        $('.campaign-carousel .slick-track .slick-slide:first-child .campaign-carousel-row .campaign-carousel-left,.campaign-carousel .slick-track .slick-slide:first-child .campaign-carousel-row .campaign-carousel-right').css('opacity', '0');
    });

    $('.campaign-carousel .slick-track .slick-slide:first-child .campaign-carousel-row .campaign-carousel-left').css('opacity', '1');
    $('.campaign-carousel .slick-track .slick-slide:first-child .campaign-carousel-row .campaign-carousel-right').css('opacity', '1');
};

sidebarOperations = function () {
    if ($('#nav-icon').length > 0) {
        $('#nav-icon').on('click', function () {
            var $sidebar = $('section.sidebar');
            if ($(this).hasClass('open')) {
                $(this).removeClass('open');
                $sidebar.removeClass('open');
                $('body').removeClass('openToggle');
                $('html').removeClass('openToggle');
            }
            else {
                $(this).addClass('open');
                $sidebar.addClass('open');
                $sidebar.removeClass('nonopen');
                $('body').addClass('openToggle');
                $('html').addClass('openToggle');
            }
        });
    }
};

niceScrollOperations = function () {
    if ($('section.campaign-detail .desktop-channel .tab-content .tab-pane').length > 0) {
        $('section.campaign-detail .desktop-channel .tab-content .tab-pane').niceScroll({
            cursorcolor: '#672E85',
            cursorwidth: '6px',
            background: 'rgb(216,216,216,0.5)',
            cursorminheight: 30,
            disableoutline: true,
            railoffset: 20,
            autohidemode: false,
            zindex: -1
        });
    }

    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
        $('section.campaign-detail .desktop-channel .tab-content .tab-pane').niceScroll();
    });
};

var isMobile = false;
isMobileOperations = function () {
    if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
        || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {
        isMobile = true;
    }
};

creditCardOperations = function () {
    if ($('#paymentPayForm').length > 0) {
        const year_selector = 'select[name="drpExpiryYear"]';
        const month_selector = 'select[name="drpExpiryMonth"]';

        $(month_selector).change(function () {
            year = $(year_selector).val() === '' || $(year_selector).val() === 'Seçiniz' ? '**' : $(year_selector).val();

            if ($(this).val() !== 'Seçiniz') {
                $('.jp-card-expiry').text($(this).val() + '/' + year);

                $('#drpExpiryMonth').val($(this).val());
            }
            else {
                $('.jp-card-expiry').text('**/' + year);
                $(year_selector).val('');

                $('#drpExpiryMonth').val(0);
            }
        });

        $(year_selector).change(function () {
            month = $(month_selector).val() === '' || $(month_selector).val() === 'Seçiniz' ? '**' : $(month_selector).val();

            if ($(this).val() !== 'Seçiniz') {
                $('.jp-card-expiry').text(month + '/' + $(this).val());

                $('#drpExpiryYear').val($(this).val());
            }
            else {
                $('.jp-card-expiry').text(month + '/**');
                $(month_selector).val('');

                $('#drpExpiryYear').val(0);
            }
        });

        $(month_selector).add(year_selector).on('focus', function () {
            $('.jp-card-expiry').addClass('jp-card-focused');
        }).on('blur', function () {
            $('.jp-card-expiry').removeClass('jp-card-focused');
        });

        if ($('.jp-card-expiry.jp-card-display').length > 0) {
            $('.jp-card-expiry.jp-card-display').attr({
                'data-before': "",
                'data-after': "SKT"
            });
        }

        $('#paymentPayForm').card({
            container: '#card-wrapper',
            formSelectors: {
                numberInput: 'input[name="cardNumber"]',
                cvcInput: 'input[name="cvcNumber"]',
                nameInput: 'input[name="cardFullname"]'
            },
            placeholders: {
                number: '____ ____ ____ ____',
                name: '********',
                expiry: '**/**',
                cvc: '***'
            },
            messages: {
                validDate: 'expire\ndate',
                monthYear: 'mm/yy'
            },
            formatting: true
        });
    }
};

//test = function (value) {
//    console.log(value);
//    if (value === '') return true;
//    console.log(value);
//    if (value === '00000000000') return false;
//    if (value.length === 11) {
//        console.log(value);
//            let totalX = 0;
//            for (var i = 0; i < 10; i++) {
//                totalX += Number(value.substr(i, 1));
//            }
//            let isRuleX = totalX % 10 === value.substr(10, 1);
//            let totalY1 = 0;
//            let totalY2 = 0;
//            for (let i = 0; i < 10; i += 2) {
//                totalY1 += Number(value.substr(i, 1));
//            }
//            for (let x = 1; x < 10; x += 2) {
//                totalY2 += Number(value.substr(x, 1));
//            }
//            var isRuleY = (totalY1 * 7 - totalY2) % 10 === value.substr(9, 0);
//            return isRuleX && isRuleY;
//        } else return false;
//    };

function goBack() {
    window.history.back();
}

var isCampaignVisible = true;
$(document).ready(function () {
    validateOperations();
    maskOperations();
    sliderOperations();
    alertOperations();
    animateOperations();
    owlCarouselOperations();
    isMobileOperations();
    creditCardOperations();
    cardValidateOperations();
    apiOperations();
    dateOperations();
    toastOperations();

    if ($('#paymentPayForm').length > 0) {
        $('#paySubmit').on('click', function (event) {
            event.preventDefault();
            $('.loading-wrap').addClass('active');
            $("#paymentPayForm").submit();
        });
    }

    if ($('.campaign-carousel').length > 0) {
        slickSliderOperations();
    }
    sidebarOperations();
    //if ($('section.campaign-detail .desktop-channel .tab-content .tab-pane').length > 0) {
    //    niceScrollOperations();
    //}

    if ($('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2).hover .campaign-bottom .bg-color').length > 0) {
        $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer:nth-child(2).hover .campaign-bottom .bg-color').stop().animate({
            'background-color': '#3F0E58',
            'width': '100%'
        }, 500);
    }

    if ($('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer .campaign .campaign-middle').length > 0) {
        $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer .campaign .campaign-middle').each(function () {
            var arr;
            var price = $(this).find('.priceNumber').val();
            if (price.indexOf(',') > -1) {
                arr = price.split(',');
                $(this).find('.newPrice').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price.indexOf('.') > -1) {
                arr = price.split('.');
                $(this).find('.newPrice').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }


    if ($('section.mobile-slider-content .mobile-sliderWrap .mobile-sliderArea .campaign .campaign-bottom').length > 0) {
        $('section.mobile-slider-content .mobile-sliderWrap .mobile-sliderArea .campaign .campaign-bottom').each(function () {
            var arr;
            var price = $(this).find('.priceNumber').val();
            if (price.indexOf(',') > -1) {
                arr = price.split(',');
                $(this).find('.newPrice').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price.indexOf('.') > -1) {
                arr = price.split('.');
                $(this).find('.newPrice').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }

    if ($('section.mobile-slider-content .mobile-sliderWrap .mobile-sliderArea .asddd .campaign .campaign-bottom ').length > 0) {
        $('section.mobile-slider-content .mobile-sliderWrap .mobile-sliderArea .asddd .campaign .campaign-bottom').each(function () {

            var arrr;
            var price2 = $(this).find('.priceNumber2').val();
            if (price2.indexOf(',') > -1) {
                arrr = price2.split(',');
                $(this).find('.newPrice2').append(arrr[0] + '<sup class="f-10">AYDA</sup>');
                for (var ab = 1; ab < arrr.length; ab++) {
                    $(this).find('.newPrice2').append('<sub class="f-18">' + "," + arrr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price2.indexOf('.') > -1) {
                arrr = price2.split('.');
                $(this).find('.newPrice2').append(arrr[0] + '<sup class="f-10">AYDA</sup>');
                for (var b = 1; b < arrr.length; b++) {
                    $(this).find('.newPrice2').append('<sub class="f-18">' + "." + arrr[1] + '<span>TL</span>' + '</sub>');
                }
            }

            var arrrr;
            var price3 = $(this).find('.priceNumber3').val();
            if (price3.indexOf(',') > -1) {
                arr = price3.split(',');
                $(this).find('.newPrice3').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice3').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price3.indexOf('.') > -1) {
                arr = price3.split('.');
                $(this).find('.newPrice3').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice3').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }

    if ($('section.campaign-detail.has-price').length > 0) {
        $('section.campaign-detail.has-price').each(function () {
            var arr;
            var price = $(this).find('.priceNumber').val();
            if (price.indexOf(',') > -1) {
                arr = price.split(',');
                $(this).find('.newPrice').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price.indexOf('.') > -1) {
                arr = price.split('.');
                $(this).find('.newPrice').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }

    if ($('section.campaign-detail.campaign-all.has-price .media-area .desc-card').length > 0) {
        $('section.campaign-detail.campaign-all.has-price .media-area .desc-card').each(function () {
            var arr;
            var price = $(this).find('.priceNumber').val();
            if (price.indexOf(',') > -1) {
                arr = price.split(',');
                $(this).find('.newPrice').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price.indexOf('.') > -1) {
                arr = price.split('.');
                $(this).find('.newPrice').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }







    if ($('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer .campaign .campaign-middle').length > 0) {
        $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer .campaign .campaign-middle').each(function () {
            var arr;
            var price2 = $(this).find('.priceNumber').val();
            if (price2.indexOf(',') > -2) {
                arr = price2.split(',');
                $(this).find('.newPrice2').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice2').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price2.indexOf('.') > -2) {
                arr = price2.split('.');
                $(this).find('.newPrice2').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice2').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }


    if ($('section.campaign-detail.has-price').length > 0) {
        $('section.campaign-detail.has-price').each(function () {
            var arr;
            var price2 = $(this).find('.priceNumber').val();
            if (price2.indexOf(',') > -1) {
                arr = price2.split(',');
                $(this).find('.newPrice2').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice2').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price2.indexOf('.') > -1) {
                arr = price2.split('.');
                $(this).find('.newPrice2').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice2').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }

    if ($('section.campaign-detail.campaign-all.has-price .media-area .desc-card').length > 0) {
        $('section.campaign-detail.campaign-all.has-price .media-area .desc-card').each(function () {
            var arr;
            var price2 = $(this).find('.priceNumber').val();
            if (price2.indexOf(',') > -1) {
                arr = price2.split(',');
                $(this).find('.newPrice2').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice2').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price2.indexOf('.') > -1) {
                arr = price2.split('.');
                $(this).find('.newPrice2').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice2').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }

    //




    if ($('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer .campaign .campaign-middle').length > 0) {
        $('section.slider-content .sliderWrap .sliderArea .campaign-area .all-campaign .campaign-outer .campaign .campaign-middle').each(function () {
            var arr;
            var price3 = $(this).find('.priceNumber').val();
            if (price3.indexOf(',') > -1) {
                arr = price.split(',');
                $(this).find('.newPrice3').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice3').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price3.indexOf('.') > -1) {
                arr = price3.split('.');
                $(this).find('.newPrice3').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice3').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }

    if ($('section.campaign-detail.has-price').length > 0) {
        $('section.campaign-detail.has-price').each(function () {
            var arr;
            var price3 = $(this).find('.priceNumber').val();
            if (price3.indexOf(',') > -1) {
                arr = price3.split(',');
                $(this).find('.newPrice3').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice3').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price3.indexOf('.') > -1) {
                arr = price3.split('.');
                $(this).find('.newPrice3').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice3').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }

    if ($('section.campaign-detail.campaign-all.has-price .media-area .desc-card').length > 0) {
        $('section.campaign-detail.campaign-all.has-price .media-area .desc-card').each(function () {
            var arr;
            var price3 = $(this).find('.priceNumber').val();
            if (price3.indexOf(',') > -1) {
                arr = price3.split(',');
                $(this).find('.newPrice3').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var i = 1; i < arr.length; i++) {
                    $(this).find('.newPrice3').append('<sub class="f-18">' + "," + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
            else if (price3.indexOf('.') > -1) {
                arr = price3.split('.');
                $(this).find('.newPrice3').append(arr[0] + '<sup class="f-10">AYDA</sup>');
                for (var x = 1; x < arr.length; x++) {
                    $(this).find('.newPrice3').append('<sub class="f-18">' + "." + arr[1] + '<span>TL</span>' + '</sub>');
                }
            }
        });
    }




    if ($('section.campaign-detail #accordion .card .card-header').length > 0) {
        $('section.campaign-detail #accordion .card .card-header').on('click', function () {
            $(this).toggleClass('active');
        });
    }

    var isModal = localStorage.getItem('isModal');
    var isForm = localStorage.getItem('isForm');
    var isFormPhoneNumber = localStorage.getItem('isFormPhoneNumber');
    var isButton = localStorage.getItem('isButton');

    if (isModal === null && isForm === null && isFormPhoneNumber === null && isButton === null) {
        isCampaignVisible = false;
    } else {
        if (isModal !== null) {
            let item = JSON.parse(isModal);
            if (Date.parse(item.expiry) < new Date()) {
                localStorage.removeItem("isModal");
            }
        }
        else if (isForm !== null) {
            let item = JSON.parse(isForm);
            if (Date.parse(item.expiry) < new Date()) {
                localStorage.removeItem("isForm");
            }
        }
        else if (isFormPhoneNumber !== null) {
            let item = JSON.parse(isFormPhoneNumber);
            if (Date.parse(item.expiry) < new Date()) {
                localStorage.removeItem("isFormPhoneNumber");
            }
        }
        else if (isButton !== null) {
            let item = JSON.parse(isButton);
            if (Date.parse(item.expiry) < new Date()) {
                localStorage.removeItem("isButton");
            }
        }

        $("#playModal").remove();
    }

    if ($('.formModal').length > 0) {
        $('.formModal').on('shown.bs.modal', function (e) {
            let now = new Date();
            now.setMinutes(now.getMinutes() + 15);
            let item = {
                value: true,
                expiry: now
            };
            localStorage.setItem('isModal', JSON.stringify(item));
            isCampaignVisible = true;
            $("#playModal").remove();
        });
    }

    if ($('#playModal').length > 0) {
        $('#playModal').on('hidden.bs.modal', function (e) {
            let now = new Date();
            now.setMinutes(now.getMinutes() + 15);
            let item = {
                value: true,
                expiry: now
            };
            localStorage.setItem('isModal', JSON.stringify(item));
            isCampaignVisible = true;
            $("#playModal").remove();
        });
    }

    if ($('.appealForm').length > 0) {

        $('.appealForm #name').focus(function () {
            let now = new Date();
            now.setMinutes(now.getMinutes() + 15);
            let item = {
                value: true,
                expiry: now
            };
            localStorage.setItem('isForm', JSON.stringify(item));
            isCampaignVisible = true;
            $("#playModal").remove();
        });

        $('.appealForm #phone').focus(function () {
            let now = new Date();
            now.setMinutes(now.getMinutes() + 15);
            let item = {
                value: true,
                expiry: now
            };
            localStorage.setItem('isForm', JSON.stringify(item));
            isCampaignVisible = true;
            $("#playModal").remove();
        });

        $("#rightFormPhoneNumber").hover(function () {
            $(this).data('timeout', setTimeout(function () {
                let now = new Date();
                now.setMinutes(now.getMinutes() + 15);
                let item = {
                    value: true,
                    expiry: now
                };
                localStorage.setItem('isFormPhoneNumber', JSON.stringify(item));
                isCampaignVisible = true;
                $('input#isModalControl').val("1");
                $("#playModal").remove();
            }, 1000));
        }, function () {
            clearTimeout($(this).data('timeout'));
        });
    }

    if ($('#playCampaignButton').length > 0) {
        $("#playCampaignButton").click(function () {
            let now = new Date();
            now.setMinutes(now.getMinutes() + 15);
            let item = {
                value: true,
                expiry: now
            };
            localStorage.setItem('isButton', JSON.stringify(item));
            isCampaignVisible = true;
            //$("#playModal").remove();
        });
    }

    if (!isMobile) {
        glio.init(
            ['top', function () {
                $('#playModal').modal('show');
            }],
            ['top-left', function () {
                $('#playModal').modal('show');
            }
            ],
            ['top-right', function () {
                $('#playModal').modal('show');
            }
            ]
        );
    }

});

cardValidateOperations = function () {
    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
        "Alanı kontrol ediniz."
    );

    if ($('.contactForm').length > 0) {
        $('.contactForm').validate({
            rules: {
                name: { required: true, regex: "^[a-zA-Z çÇşŞöÖıİüÜğĞ*]{1,50}$", maxlength: 50 },
                phone: "required"
            },
            messages: {
                name: {
                    required: "Ad Soyad alanı zorunludur.",
                    maxlength: "Ad Soyad alanı 50 karakteri geçemez.",
                    regex: "Ad Soyad alanını kontrol ediniz."
                },
                phone: "Telefon alanı zorunludur."
            }
        });
    }

    if ($('#cancelForm').length > 0) {
        let message = "Zorunlu";
        $('#cancelForm').validate({
            rules: {
                name: "required",
                email: {
                    required: true,
                    email: true
                },
                subject: "required",
                message: "required"
            },
            invalidHandler: function (form, validator) {
                for (var i = 0; i < validator.errorList.length; i++) {
                    $(validator.errorList[i].element).attr('placeholder', validator.errorList[i].message);
                }
            },
            highlight: function (element, errorClass) {
                $(element).parent('div').addClass('error');
            },
            success: function (element, label) {
                $(element).parent('div').removeClass('error');
            },
            messages: {
                name: message,
                email: message,
                subject: message,
                message: message
            }
        });
    }

    if ($('.appealForm').length > 0) {
        $('.appealForm').validate({
            rules: {
                name: { required: true, regex: "^[a-zA-Z çÇşŞöÖıİüÜğĞ*]{1,50}$", maxlength: 50 },
                phone: "required"
            },
            messages: {
                name: {
                    required: "Ad Soyad alanı zorunludur.",
                    maxlength: "Ad Soyad alanı 50 karakteri geçemez.",
                    regex: "Ad Soyad alanını kontrol ediniz."
                },
                phone: "Telefon alanı zorunludur."
            }
        });
    }

    if ($('#modalForm').length > 0) {
        $('#modalForm').validate({
            rules: {
                name: { required: true, regex: "^[a-zA-Z çÇşŞöÖıİüÜğĞ\\s]{1,50}$", maxlength: 50 },
                phone: "required"
            },
            messages: {
                name: {
                    required: "Ad Soyad alanı zorunludur.",
                    maxlength: "Ad Soyad alanı 50 karakteri geçemez.",
                    regex: "Ad Soyad alanını kontrol ediniz."
                },
                phone: "Telefon alanı zorunludur."
            }
        });
    }

    if ($('#paymentPayForm').length > 0) {
        //const country_selector = $('select[name="country"]').val();
        //if (country_selector === '') {
        //    $('select[name="country"]').val(0);
        //}
        $('#paymentPayForm').validate({
            rules: {
                cardFullname: { required: true, regex: "^[a-zA-Z çÇşŞöÖıİüÜğĞ*]{1,50}$", maxlength: 50 },
                cardNumber: "required",
                cvcNumber: "required",
                drpExpiryMonth: "required",
                drpExpiryYear: "required",
                cardPhoneNumber: "required",
                //gender: "required",
                //country: "required",
                //city: "required",
                //postCode: "required",
                //address: "required",
                day: "required",
                month: "required",
                year: "required",
                installment: "required",
                identity: { required: true, maxlength: 11, minlength: 11},
                cardEmail: {
                    required: true,
                    email: true
                }
            },
            invalidHandler: function (form, validator) {
                for (var i = 0; i < validator.errorList.length; i++) {
                    $(validator.errorList[i].element).attr('placeholder', validator.errorList[i].message);
                }
            },
            highlight: function (element, errorClass) {
                $(element).addClass(errorClass).parent().prev().children("select").addClass(errorClass);
                $(element).parent('div').addClass('error');
                $('.loading-wrap').removeClass('active');
            },
            success: function (element, label) {
                $(element).parent('div').removeClass('error');
            },
            messages: {
                cardFullname: "Zorunlu",
                cardNumber: "Zorunlu",
                cvcNumber: "Zorunlu",
                drpExpiryMonth: "Zorunlu",
                drpExpiryYear: "Zorunlu",
                cardPhoneNumber: "Zorunlu",
                cardEmail: "Zorunlu",
                //gender: "Zorunlu",
                //country: "Zorunlu",
                //city: "Zorunlu",
                //postCode: "Zorunlu",
                //address: "Zorunlu",
                day: "Zorunlu",
                month: "Zorunlu",
                year: "Zorunlu",
                installment: "Zorunlu",
                identity: "Zorunlu"
            }
        });
    }
};

dateOperations = function () {
    if ($('#year').length > 0) {
        let min = 1921;
        let max = new Date().getFullYear() - 18;
        let currentSelect = document.getElementById('year');
        for (var i = min; i <= max; i++) {
            var opt = document.createElement('option');
            opt.value = i;
            opt.innerHTML = i;
            currentSelect.appendChild(opt);
        }

        var $select = $('#year');
        var options = $select.find('option');
        options = [].slice.call(options).reverse();
        const firstChild = $select.find('option:first-child');
        $select.empty();
        $.each(options, function (i, el) {
            $select.append($(el));
        });
        $select.prepend(firstChild);
        $select.val('');
    }
};

toastOperations = function () {
    if ($('#resultMessage').length > 0) {
        const messageType = $('#resultMessage').attr('data-type');
        const message = $('#resultMessage').val();

        //if (messageType === "success") {
        //    $.toast({
        //        text: message,
        //        bgColor: "#1BAE00",
        //        position: "top-center",
        //        textColor: "#fff",
        //        hideAfter: 5000,
        //        icon: 'success'
        //    });
        //}

        if (messageType === "error") {
            if ($('.loading-wrap').hasClass('active')) {
                $('.loading-wrap').removeClass('active');
            }

            $.toast({
                text: message,
                bgColor: "#E8626D",
                position: "top-center",
                textColor: "#fff",
                hideAfter: 10000,
                icon: 'error'
            });
            let queryString = window.location.search;
            if (queryString !== '') {
                history.replaceState(null, "", location.href.split("?")[0]);
            }
        }
    }
};

apiOperations = function () {
    if ($('#cancelForm').length > 0) {
        $('#cancelForm').submit(function (event) {
            event.preventDefault();

            var $form = $(this),
                url = $form.attr('action');

            if (!$form.valid()) return false;

            console.log($form);
            let validMessage = "";
            let invalidMessage = "";
            validMessage = "Başarılı!";
            invalidMessage = "Başarısız!";

            //$.ajax({
            //    url: url,
            //    type: 'POST',
            //    contentType: "application/json",
            //    dataType: 'json',
            //    data: '{ "FullName": "' + $(this).find('#name').val() + '", "Email": "' + $(this).find('#email').val() + '", "Subject": "' + $(this).find('#subject').val() + '", "Message": "' + $(this).find('#message').val() + '"  }',
            //    success: function (data) {
            //        if (data.status.code === 0) {
            //            $.toast({
            //                text: validMessage,
            //                bgColor: "#1BAE00",
            //                position: "top-center",
            //                textColor: "#fff",
            //                hideAfter: 10000,
            //                icon: 'success'
            //            });
            //        }
            //        else {
            //            $.toast({
            //                text: invalidMessage,
            //                bgColor: "#E8626D",
            //                position: "top-center",
            //                textColor: "#fff",
            //                hideAfter: 10000,
            //                icon: 'error'
            //            });
            //        }
            //    }
            //});

        });
    }
};

function setModalInputs(plan, price, permalink) {
    $('input[name="campaign_name"]').val(plan);
    $('input[name="permalink"]').val(permalink);
    $('input[name="price"]').val(price);
    $('.formModal').modal('toggle');
}

function SendUtmParameter(e) {
    var hubJsonData = JSON.parse(localStorage.getItem('hubData'));
    if (hubJsonData !== null && hubJsonData.utm_id !== undefined && diff_hours(hubJsonData.timestamp, new Date().getTime()) <= 1) {
        $(e).closest('form').append('<input type="hidden" name="utm_id" value="' + hubJsonData.utm_id + '" />');
        $(e).closest('form').append('<input type="hidden" name="utm_medium" value="' + hubJsonData.utm_medium + '" />');
        $(e).closest('form').append('<input type="hidden" name="utm_source" value="' + hubJsonData.utm_source + '" />');
        $(e).closest('form').append('<input type="hidden" name="utm_term" value="' + hubJsonData.utm_term + '" />');
    }

    if ($(e).closest('form').valid()) {
        $(e).click(false).css({
            'opacity': '0.8',
            'pointer-events': 'none',
            'cursor': 'default'
        });
        $(e).closest('form').submit();
    }
}

function diff_hours(dt2, dt1) {
    var diff = (dt2 - dt1) / 1000;
    diff /= (60 * 60);
    return Math.abs(Math.round(diff));
}

function setCookie(key, value) {
    var expires = new Date();
    expires.setTime(expires.getTime() + (1 * 24 * 60 * 60 * 1000));
    document.cookie = key + '=' + value + ';expires=' + expires.toUTCString();
}

function getCookie(key) {
    var keyValue = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
    return keyValue ? keyValue[2] : null;
}
