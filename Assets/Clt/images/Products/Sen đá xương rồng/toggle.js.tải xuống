// JavaScript Document

 
/*--------------------LOGIN--------------------*/
$(document).ready(function(){
	$(".login-block").hide();
    $(".login a.put-login").click(function(){
        $(".login-block").toggle("swing"); 
    });
});
 

/*--------------------SEARCH--------------------*/
$(document).ready(function(){
	$(".box-search").hide();
    $(".search-button").click(function(){
        $(".box-search").toggle();
 
    });
});
 
 
/*UP-TOP*/
$(document).ready(function () {
      $().UItoTop();
  });
   
/*--------------------BANNER--------------------*/
	var owl_me;
	var h_wr = $('.wrapper').height();
	var h_ = $(window).height();
function Page(){
	var self = this;
	
	this.init = function(){	
		if($('.banner-slider').length>0 && $('.owl-slider .item').length>1){
			owl_me = $('.owl-slider');
			owl_me.on('initialized.owl.carousel', function(event) {
				$('.banner-slider .owl-carousel').addClass('load-cl');
			})
			owl_me.owlCarousel({
				autoplay: true,
				smartSpeed: 500,
				items: 1,
				loop:true,
				margin:0,
				nav: true,
				callbacks: true
			});
		}
		$('.banner-slider .owl-prev').click(function() {
			owl_me.trigger('prev.owl.carousel', [300]);
		})
		$('.banner-slider .owl-next').click(function() {
			owl_me.trigger('next.owl.carousel');
		})
		/*$(window).load(function(){
			h_wr = $('.wrapper').height();
			self.resize_height();
		})
		$(window).resize(function(){
			self.resize_height();
		})*/
	};
   
}
Page = new Page();
$(function(){
	Page.init();
});

 
 $(document).ready(function() {
      $('#owl-demo').owlCarousel({
        autoPlay: 70000,
        items :1,
		navigationText:["",""],
		navigation: true,
		slideSpeed: 10000,
		singleItem:true,
		stopOnHover: true,
   		mouseDrag: true,			
		touchDrag: true,	
      });

    });
	
	
	
/*--------------------PRODUCT _ SLIDE--------------------*/
	$(document).ready(function() {		
	    var owl = $("#owl-2");
	    owl.owlCarousel({
		    items : 4,
			itemsDesktop : [1024,4],
			itemsDesktopSmall : [900,3],
			itemsTablet: [720,2],
			itemsMobile : [320,1],

 			slideSpeed: 500,
			paginationSpeed: 1000,
			autoPlay: 5000,
			rewindSpeed: 20000,
			
			navigationText:["",""],
			navigation: true,
			stopOnHover: true,
			lazyLoad : true,
			mouseDrag: true,
			touchDrag: true,
			
		    	    });
	});
 
 
 
 
/*-----------------STICKY--------------------*/
 var stickySidebar = $('.sticky');

if (stickySidebar.length > 0) { 
  var stickyHeight = stickySidebar.height(),
      sidebarTop = stickySidebar.offset().top;
}

// on scroll move the sidebar
$(window).scroll(function () {
  if (stickySidebar.length > 0) { 
    var scrollTop = $(window).scrollTop();
            
    if (sidebarTop < scrollTop) {
      stickySidebar.css('top', scrollTop - sidebarTop);

      // stop the sticky sidebar at the footer to avoid overlapping
      var sidebarBottom = stickySidebar.offset().top + stickyHeight,
          stickyStop = $('.main-content').offset().top + $('.main-content').height();
      if (stickyStop < sidebarBottom) {
        var stopPosition = $('.main-content').height() - stickyHeight;
        stickySidebar.css('top', stopPosition);
      }
    }
    else {
      stickySidebar.css('top', '0');
    } 
  }
});

$(window).resize(function () {
  if (stickySidebar.length > 0) { 
    stickyHeight = stickySidebar.height();
  }
});// JavaScript Document




 
 

/*SLIDE IMAGE PRODUCT*/

jQuery(window).load(function() {
	jQuery("#slider-carousel").flexslider({
		animation: "slide",
		controlNav: false, 
		itemWidth: 80, 
		itemMargin: 5,
		animationLoop: false,
		slideshow: true, 
		slideshowSpeed:2000, // slider show speed
		controlsContainer: "#slider-carousel .flex-nav-container",
		asNavFor: "#slider-1",  // slider ID                                         
		prevText: "←", 
		nextText: "→"  
	});

	jQuery("#slider-1").flexslider({
		animation: "slide",
		controlNav: false,
		animationLoop: false,
		slideshowSpeed:8000, // carousel show speed
		slideshow: true,
		smoothHeight: true,
		directionNav: false,
		sync: "#slider-carousel", // carousel ID - thumbnail holder div
	}); 
}); 





/*CHAY CHU*/
$('.marquee').marquee({
    duration: 10000, //speed
    gap: 500,    //gap in pixels between the tickers
    delayBeforeStart: 0,
    scrollamount:1,
    direction: 'left',     //Left - right
    duplicated: true,
  	pauseOnHover: true  //stop hover
});




/*QUANGCAO2BEN*/
 function FloatTopDiv()   
    {   
        startLX = ((document.body.clientWidth -MainContentW)/2)-LeftBannerW-LeftAdjust , startLY = TopAdjust+80;   
        startRX = ((document.body.clientWidth -MainContentW)/2)+MainContentW+RightAdjust , startRY = TopAdjust+80;   
        var d = document;   
        function ml(id)   
        {   
            var el=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id]; 
            el.sP=function(x,y){this.style.left=x + 'px';this.style.top=y + 'px';};   
            el.x = startRX;   
            el.y = startRY;   
            return el;   
        }   
        function m2(id)   
        {   
            var e2=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id];   
            e2.sP=function(x,y){this.style.left=x + 'px';this.style.top=y + 'px';};   
            e2.x = startLX;   
            e2.y = startLY;   
            return e2;   
        }   
        window.stayTopLeft=function()   
        {   
            if (document.documentElement && document.documentElement.scrollTop)   
                var pY =  document.documentElement.scrollTop;   
            else if (document.body)   
                var pY =  document.body.scrollTop;   
             if (document.body.scrollTop > 30){startLY = 3;startRY = 3;} else  {startLY = TopAdjust;startRY = TopAdjust;};   
            ftlObj.y += (pY+startRY-ftlObj.y)/16;   
            ftlObj.sP(ftlObj.x, ftlObj.y);   
            ftlObj2.y += (pY+startLY-ftlObj2.y)/16;   
            ftlObj2.sP(ftlObj2.x, ftlObj2.y);   
            setTimeout("stayTopLeft()", 1);   
        }   
        ftlObj = ml("divAdRight");   
        //stayTopLeft();   
        ftlObj2 = m2("divAdLeft");   
        stayTopLeft();   
    }   
    function ShowAdDiv()   
    {   
        var objAdDivRight = document.getElementById("divAdRight");   
        var objAdDivLeft = document.getElementById("divAdLeft");     
        if (document.body.clientWidth < 1000)   
        {   
            objAdDivRight.style.display = "none";   
            objAdDivLeft.style.display = "none";   
        }   
        else   
        {   
            objAdDivRight.style.display = "block";   
            objAdDivLeft.style.display = "block";   
            FloatTopDiv();   
        }   
    }
	
	
/*-----------------TOGGLE_MENU-------------------*/				
			 
(function(jQuery){
     jQuery.fn.extend({  
         accordion: function() {       
            return this.each(function() { 
            });
        } 
    }); 
})(jQuery);
 
   
$(document).ready(function() {		
jQuery("#menu-icon").on("click", function(){	
  jQuery(".sf-menu-phone").slideToggle();
  jQuery(this).toggleClass("active");
 });
    
  jQuery('.sf-menu-phone').find('li.parent').append('<i class="fa fa-chevron-down"></i>');
  jQuery('.sf-menu-phone li.parent i').on("click", function(){
   if (jQuery(this).hasClass('icon-angle-up')) { jQuery(this).removeClass('icon-angle-up').parent('li.parent').find('> ul').slideToggle(); } 
    else {
     jQuery(this).addClass('icon-angle-up').parent('li.parent').find('> ul').slideToggle();
    }
  }); 
});

  
/*-----------------PRODUCT_SLIDE--------------------*/	
 $(document).ready(function() {
  $('.owl-carousel').owlCarousel({
	loop: false,
	margin: 20,
	nav: true,
	dots: false,
	autoplay:5,				
	autoplaySpeed:500,
	responsiveClass: true,
	responsive: {
	  0:{items: 1},	
	  520:{items: 2},  
	  681:{items: 3},	
	  1200:{items: 3}
	}
  })
}) 
		
/*-----------------CUSTOMER-SLIDE--------------------*/				
 $(document).ready(function() {
  $('.block-slider-customer .owl-carousel-1').owlCarousel({
	loop: false,
	margin: 0,
	nav: false,
	dots: false,        
	vertical: true,
	autoplay:5,				
	autoplaySpeed:500,
	responsiveClass: true,
	responsive: {
	  0:{items: 2},
	  500:{items: 5},
	  1000:{items: 6},
	  1200:{items: 8}
	}
  })
})
 
 

/*--------------------STICKY-MENU-HEADER--------------------*/
 
 // When the user scrolls the page, execute myFunction 
window.onscroll = function() {myFunction()};
var navbar = document.getElementById("navbar");
var sticky = navbar.offsetTop;

function myFunction() {
  if (window.pageYOffset >= sticky) {
    navbar.classList.add("sticky")
  } else {
    navbar.classList.remove("sticky");
  }
}


/*--------------------VERTICAL-SLIDER--------------------*/
    $(document).on('ready', function() {    
      $(".vertical").slick({
        dots: false,
		autoplay:1,
        vertical: true,
        slidesToShow: 5,
        slidesToScroll: 1
      }); 
    });
	
	
	
	
	
/*--------------------TOGGLE_MENU--------------------*/	
$(document).ready(function () {
	$("#accordian h3").click(function () {
		//slide up all the link lists
		$("#accordian ul ul").slideUp();
		$("#accordian li").removeClass("active");
		//slide down the link list below the h3 clicked - only if its closed
		if (!$(this).next().is(":visible")) {
			$(this).parent().addClass("active");
			$(this).next().slideDown();
		}
	})
})