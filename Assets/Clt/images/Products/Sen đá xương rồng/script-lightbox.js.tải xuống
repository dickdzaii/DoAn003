

/* ******************************************************************************* 

	IMAGE PRELOAD v1.5  - https://github.com/farinspace/jquery.imgpreload  

********************************************************************************** */  
if("undefined"!=typeof jQuery){(function(a){a.imgpreload=function(b,c){c=a.extend({},a.fn.imgpreload.defaults,c instanceof Function?{all:c}:c);if("string"==typeof b){b=new Array(b)}var d=new Array;a.each(b,function(e,f){var g=new Image;var h=f;var i=g;if("string"!=typeof f){h=a(f).attr("src")||a(f).css('background-image').replace(/^url\((?:"|')?(.*)(?:'|")?\)$/mg, "$1");i=f}a(g).bind("load error",function(e){d.push(i);a.data(i,"loaded","error"==e.type?false:true);if(c.each instanceof Function){c.each.call(i)}if(d.length>=b.length&&c.all instanceof Function){c.all.call(d)}a(this).unbind("load error")});g.src=h})};a.fn.imgpreload=function(b){a.imgpreload(this,b);return this};a.fn.imgpreload.defaults={each:null,all:null}})(jQuery)}

/* ******************************************************************************* 

	PRELOADED IMAGES

********************************************************************************** */  
(function($){
	"use strict";

	if( ! $.fn.rt_imgpreload ){

		$.fn.rt_imgpreload = function(options)
		{ 
				var holder = $(this);
				var image = $(this).find("img"); 

				$( holder ).addClass("img_loading");

				image.imgpreload
				({
					each: function()
					{ 
						if( $(this).data('loaded') ){ 
							holder.removeClass("img_loading").addClass("img_loaded"); 
						}				
					}
				});
		}
		$(".imgeffect, .featured_image_holder, .product_boxes .featured_image").rt_imgpreload();  
	}

})(jQuery);  

/* ******************************************************************************* 

	HOVER EFFECT FOR PRODUCT SHOWCASE
	(new one version 1.3)

********************************************************************************** */ 
(function($){
	"use strict"; 

	$.fn.rt_product_hover_effect = function(options) {

		var settings = $.extend({}, $.fn.rt_product_hover_effect.defaults, options);
 
		$(this).on("mouseover mouseleave",function(event) { 

			var item_width = $(this).width(),
				item_height =  $(this).height(),
				product_info = $(this).find(".product_info"), 
				product_info_layer = $(this).find(".product_info > div"),
				featured_image = $(this).find(".featured_image");

			
			$(this).css({"overflow":"hidden"});

			if( $(window).width() > 550 ){
				product_info.css({
					"width":item_width+"px",
					"height":item_height+"px",
					"position":"absolute",
					"top":"0",
					"left":"0",
					"overflow":"auto",
					"display":"block",
					"opacity":"0",
				}).addClass("box_sizing animated"); 

				featured_image.addClass("animated");

				if(event.type == "mouseover"){ 
					product_info.css({"opacity":"1"}).addClass("fadeIn");
					
					if( product_info.length > 0 ){
						featured_image.css({"opacity":"0.07"}); 	
					} else{
						featured_image.css({"opacity":"0.5"}); 
					}
				}

				if(event.type == "mouseleave"){				 
					product_info.css({"opacity":"0"}).removeClass("fadeIn");
					featured_image.css({"opacity":"1"});
				}

			}
 

		}); 

	}; 

	//run the script
	$(window).on('load resize', function() {  
		$('.product-showcase .with_effect > .box').rt_product_hover_effect(); 
	});

})(jQuery);  


/* ******************************************************************************* 

	HOVER EFFECT FOR WOOCOMMERCE PRODUCTS  

********************************************************************************** */ 
(function($){
	"use strict"; 

	$.fn.rt_wc_product_hover_effect = function(options) {

		var settings = $.extend({}, $.fn.rt_wc_product_hover_effect.defaults, options);
 
		$(this).on("mouseover mouseleave",function(event) { 

			var item_width = $(this).width(),
				item_height =  $(this).height(),
				product_info = $(this).find(".product_info"),
				product_info_layer = $(this).find(".product_info > div"),
				onsale = $(this).find(".onsale"),
				featured_image = $(this).find(".featured_image");

			
			$(this).css({"overflow":"hidden"});

			if( $(window).width() > 550 ){
				product_info.css({
					"width":item_width+"px",
					"height":item_height+"px",
					"position":"absolute",
					"top":"0",
					"left":"0",
					"overflow":"auto",
					"display":"table",
					"opacity":"0",
				}).addClass("box_sizing").addClass("animated");

				product_info_layer.css({
					"display":"table-cell",
					"vertical-align":"middle",
				}).addClass("box_sizing").addClass("animated");

				featured_image.addClass("animated");

				if(event.type == "mouseover"){ 
					product_info.css({"opacity":"1"}).addClass("fadeIn");
					featured_image.css({"opacity":"0.03"});  
					onsale.css({"display":"none"});  
				}

				if(event.type == "mouseleave"){				 
					product_info.css({"opacity":"0"}).removeClass("fadeIn");
					featured_image.css({"opacity":"1"});
					onsale.css({"display":"block"});  
				}

			}
 

		}); 

	}; 

	//run the script
	$(window).on('load resize', function() {  
		$('.woocommerce.product_boxes .with_effect > .box').rt_wc_product_hover_effect(); 
	});

})(jQuery);  


/* ******************************************************************************* 

	LIGHTBOX PLUGIN

********************************************************************************** */    
(function($){
	"use strict";
	if ($.jackBox){
		$(".lightbox_[data-group]").jackBox("init", { preloadGraphics: false, baseName: lightbox_params[""] +"/js/lightbox", className: ".lightbox_", deepLinking : false, socialMedia : false, showInfoByDefault: true});  
	}
})(jQuery); 


