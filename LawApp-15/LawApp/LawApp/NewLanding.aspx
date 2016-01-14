<%@ Page Title="My Law Tools - Next Generation Attorney Tools" Language="C#" AutoEventWireup="true" CodeBehind="NewLanding.aspx.cs" Inherits="LawAppWeb.NewLanding" %>


<!DOCTYPE html>
<html lang="en">

<head runat="server">
    <title>My Law Tools - Next Generation Attorney Tools</title>
    <meta charset="utf-8" />
	<meta name="description" content="Lucy is the best Responsive App Landing Page designed with Bootstrap 3, HTML5 and CSS3. You can use this Responsive  App Landing Page for any kinds of app and game. Amazing design, creative layout and easily customizable.">
	<meta name="keywords" content="Bootstrap, Responsive, App Landing Page">
	<meta name="author" content="ThemeWagon">
	<meta name="viewport" content="width=device-width, initial-scale=1">

    <!--favicon-->
	<link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
	<link rel="icon" href="img/favicon.ico" type="image/x-icon">

    <link href="~/Content/Site.css" rel="stylesheet" /> 
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" /> 
    <link href="~/Content/bootstrap-datepicker3.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/front/libs/ionicons/css/ionicons.min.css">
	<link rel="stylesheet" href="Content/front/css/owl.carousel.css">
	<link rel="stylesheet" href="Content/front/css/owl.theme.css">
	<link rel="stylesheet" href="Content/front/css/nivo-lightbox/nivo-lightbox.css">
	<link rel="stylesheet" href="Content/front/css/nivo-lightbox/nivo-lightbox-theme.css">
	<link rel="stylesheet" href="Content/front/css/animate.css">
	<link rel="stylesheet" href="Content/front/css/style.css">
	<link rel="stylesheet" href="Content/front/css/colors/custom.css">
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,100,100italic,300,300italic,400italic,500,500italic,700,700italic,900,900italic|Roboto+Condensed:300italic,400italic,700italic,400,300,700' rel='stylesheet' type='text/css'>

    <asp:PlaceHolder runat="server">        
        <script src="<%: ResolveUrl("~/Scripts/modernizr-2.6.2.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/jquery-2.1.3.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/jquery-ui-1.11.2.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/bootstrap.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/lodash.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/bootstrap-datepicker.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/jquery.validate.min.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/Datepicker.js") %>"></script>
        <script src="<%: ResolveUrl("~/Scripts/jquery.cookie.js") %>"></script>
        <script src="/Scripts/front/js/modernizr.custom.js"></script>

	    <script src="/Scripts/front/js/wow.min.js"></script>
	    <script src="/Scripts/front/js/owl.carousel.js"></script>
	    <script src="/Scripts/front/js/nivo-lightbox.min.js"></script>
	    <script src="/Scripts/front/js/smoothscroll.js"></script>
	    <script src="/Scripts/front/js/jquery.ajaxchimp.min.js"></script>
	    <script src="/Scripts/front/js/script.js"></script>
    </asp:PlaceHolder>
    <meta name="viewport" content="width=device-width" />
</head>

<body id="home">
    <form runat="server">

	<!-- ****************************** Preloader ************************** -->
	<div id="preloader"></div>


	<!-- ****************************** Sidebar ************************** -->
	<nav id="sidebar-wrapper">
		<a id="menu-close" href="#" class="close-btn toggle">CLOSE <i class="ion-log-in"></i></a>
	    <ul class="sidebar-nav">
		    <li><a href="#home">Home</a></li>
			<li><a href="#video">Video</a></li>
			<li><a href="#bigfeatures">Features</a></li>
			<li><a href="#features">Specialty</a></li>
			<li><a href="#features-left-image">With Image</a></li>
			<li><a href="#gallery">Screenshots</a></li>
			<li><a href="#testimonial">Testimonial</a></li>
			<li><a href="#team">Team</a></li>
			<li><a href="#pricing">Pricing</a></li>
			<li><a href="#subscribe">Subscribe</a></li>
			<li><a href="#contact">Contact us</a></li>
	    </ul>
	</nav>

	
	<!-- ****************************** Header ************************** -->
	<header class="sticky" id="header">
		<div class="container">
			<div class="row" id="logo_menu">
				<div class="col-xs-6"><a class="logo" href="/">My Law Tools</a></div>
				<div class="col-xs-6"><a id="menu-toggle" href="#" class="toggle" role="button" title="Navigation" data-toggle="tooltip" data-placement="left"><i class="ion-navicon"></i></a></div>
			</div>
		</div>
	</header>



	<!-- ****************************** Banner ************************** -->
	<section id="banner" >
		<div class="banner-overlay"></div>
		<div class="container">
			<a class="slidedown wow animated zoomIn" data-wow-delay="2s" href="#video"><i class="ion-ios-download-outline"></i></a>
			<div class="row">
				<div class="col-md-6">
					<div class="headings">
						<h1 class="wow animated fadeInDown">It's Amazing</h1>
						<p class="wow animated fadeInLeft">Lucy is the best <strong>Responsive App Landing Page</strong> designed with Bootstrap 3, HTML5 and CSS3. You can use this Responsive  App Landing Page for any kinds of app and game.</p>

                        <div class="panel panel-info wow animated fadeInDown">
                            <div class="panel-heading">
                                <strong>Existing Members Login</strong>
                            </div>
                            <div class="panel-body" style="color:black;">
                                <div class="form-group">
                                    <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
                                </div>
                                <div class="form-group">
                                    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
                                </div>
                                <div class="form-group" style="text-align:right;">
                                    <asp:LinkButton runat="server" ID="lnkLogin">
                                        Login
                                    </asp:LinkButton>
                                </div>
                                <div>
                                    <a href="#">I Forgot My Password</a>
                                </div>
                            </div>
                        </div>
					</div>
				</div>
				<div class="col-md-6 hidden-xs hidden-sm">
					<div class="hand-container">
					<img class="iphone-hand img_res wow animated bounceInUp" data-wow-duration="1.2s" src="Content/front/img/iphone_hand.png" alt="">
					<div class="clearfix"></div>
					</div>
				</div>
			</div>
		</div>
	</section>


	<!-- ****************************** Video section ************************** -->
	<section id="video" class="block">
		<div class="container">
			
			<div class="title-box">
				<h1 class="block-title wow animated zoomIn">
					<span class="bb-top-left"></span>
					<span class="bb-bottom-left"></span>
					Video Preview
					<span class="bb-top-right"></span>
					<span class="bb-bottom-right"></span>
				</h1>
			</div>

			<div class="row">
				<div class="col-sm-offset-2 col-sm-8 wow animated bounceInUp">
					<!-- 16:9 aspect ratio -->
					<div class="embed-responsive embed-responsive-16by9">
                        <iframe class="embed-responsive-item" width="1280" height="720" src="https://www.youtube.com/embed/gU6hSv14J-Y" frameborder="0" allowfullscreen></iframe>
					</div>
					<p class="text-center italic">
						<strong>Timesharing Calendar is the newest addition to the My Law Tools platform.</strong>
					</p>
				</div>
			</div>
		</div>
	</section>


	<!-- ****************************** Big Features section ************************** -->
	<section id="bigfeatures" class="img-block-3col block">

		<div class="container">

			<div class="title-box">
				<h1 class="block-title wow animated zoomIn">
					<span class="bb-top-left"></span>
					<span class="bb-bottom-left"></span>
					Features
					<span class="bb-top-right"></span>
					<span class="bb-bottom-right"></span>
				</h1>
			</div>


			<div class="row">
				<div class="col-sm-4">
					<ul class="item-list-right item-list-big">
						<li class="wow fadeInLeft animated"> <i class="ion-ios-monitor-outline"></i>
							<h3>Responsive design</h3>
							<p>Your project looks great on any device. Content can be easily read and a user understands freely what you wanted.</p>
						</li>
						<li class="wow fadeInLeft animated"> <i class="ion-ios-toggle-outline"></i>
							<h3>6 Color schemes</h3>
							<p>The set of ready made CSS files with different color schemes will help you in quick landing’s adaptation according to your benchmark style.</p>
						</li>
						<li class="wow fadeInLeft animated"> <i class="ion-ios-browsers-outline"></i>
							<h3>PSD Is Included </h3>
							<p>The graphic source file in PSD format is included in the archive.</p>
						</li>
					</ul>
				</div>
				<div class="col-sm-4 col-sm-push-4">
					<ul class="item-list-left item-list-big">
						<li class="wow fadeInRight animated"> <i class="ion-ios-heart-outline"></i>
							<h3>Well Documentation</h3>
							<p>LUCY is shipped with well documented moduler codes. Meaningfull Comments in code will help you to customize it easily.</p>
						</li>
						<li class="wow fadeInRight animated"> <i class="ion-ios-information-outline"></i>
							<h3>Easily Customizable</h3>
							<p>LUCY is easy to customize. No heavy coding is required to customize it with your real contents.</p>
						</li>
						<li class="wow fadeInRight animated"> <i class="ion-ios-cart-outline"></i>
							<h3>Future Support</h3>
							<p>We will update LUCY and fix bugs if you found one for a long time.</p>
						</li>
					</ul>
				</div>
				<div class="col-sm-4 col-sm-pull-4 text-center">
					<div class="animation-box wow bounceIn animated">
						<img class="highlight-left wow animated" src="Content/front/img/spark.png" height="192" width="48" alt=""> 
						<img class="highlight-right wow animated" src="Content/front/img/spark.png" height="192" width="48" alt="">
						<img class="screen" src="Content/front/img/features_screen.png" alt="" height="581" width="300">
					</div>
				</div>
			</div>
		</div>
	</section>


	<!-- ****************************** Specialty section ************************** -->
	<section id="features" class="block">
		<div class="container">
			<div class="title-box">
				<h1 class="block-title wow animated zoomIn">
					<span class="bb-top-left"></span>
					<span class="bb-bottom-left"></span>
					Specialty
					<span class="bb-top-right"></span>
					<span class="bb-bottom-right"></span>
				</h1>
			</div>
			
			<div class="row">
				<div class="col-sm-6 col-md-4">
					<div class="feature-box wow animated flipInX animated">
						<i class="ion-android-options"></i>
						<h2>Tune up</h2>
						<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard.</p>
					</div>
				</div>
				<div class="col-sm-6 col-md-4">
					<div class="feature-box wow animated flipInX animated">
						<i class="ion-android-unlock"></i>
						<h2>Security</h2>
						<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard.</p>
					</div>
				</div>
				<div class="col-sm-6 col-md-4">
					<div class="feature-box wow animated flipInX animated">
						<i class="ion-nuclear"></i>
						<h2>Firewall</h2>
						<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard.</p>
					</div>
				</div>
				<div class="col-sm-6 col-md-4">
					<div class="feature-box wow animated flipInX animated">
						<i class="ion-beer"></i>
						<h2>HD Widgets</h2>
						<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard.</p>
					</div>
				</div>
				<div class="col-sm-6 col-md-4">
					<div class="feature-box wow animated flipInX animated">
						<i class="ion-search"></i>
						<h2>Data Sync</h2>
						<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard.</p>
					</div>
				</div>
				<div class="col-sm-6 col-md-4">
					<div class="feature-box wow animated flipInX animated">
						<i class="ion-android-sync"></i>
						<h2>Customize</h2>
						<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard.</p>
					</div>
				</div>
			</div>
			<div class="clearfix"></div>
		</div>
	</section>


	<!-- ****************************** Left Image section ************************** -->
	<section id="features-left-image" class="block">
		<div class="container">
			
			<div class="row">
				<div class="col-sm-6 wow fadeInLeft animated">
					<div class="phone-image">
						<img class="img-responsive" src="Content/front/img/2-iphone-left.png" alt="">
					</div>
				</div><!--/col-sm-6-->

				<div class="col-sm-6 wow fadeInRight animated">
					
					<div class="title-box text-left">
						<h1 class="block-title wow animated zoomIn">
							<span class="bb-top-left"></span>
							<span class="bb-bottom-left"></span>
							With Image Left
							<span class="bb-top-right"></span>
							<span class="bb-bottom-right"></span>
						</h1>
					</div>
					
					<div class="row">
						<div class="col-md-12">
							<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
							<ul class="feature-list">
								<li><i class="ion-battery-half"></i> Reliable and Secure Platform</li>
								<li><i class="ion-bug"></i> Everything is perfectly orgainized for future</li>
								<li><i class="ion-toggle"></i> Attach large file easily</li>
								<li><i class="ion-gear-a"></i> Tons of features and easy to use and customize</li>
							</ul>
						</div>
					</div>
				</div><!--/col-sm-6-->

			</div><!--/row-->
			
		</div><!--/container-->
	</section>


	<!-- ****************************** Right Image section ************************** -->
	<section id="features-right-image" class="block">
		<div class="container">
			
			<div class="row">
				<div class="col-sm-6 wow fadeInLeft animated">
					<div class="title-box text-left">
						<h1 class="block-title wow animated zoomIn">
							<span class="bb-top-left"></span>
							<span class="bb-bottom-left"></span>
							With Image Right
							<span class="bb-top-right"></span>
							<span class="bb-bottom-right"></span>
						</h1>
					</div>
					
					<div class="row">
						<div class="col-md-12">
							<p class="mb50">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
							<p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
						</div>
					</div>
				</div><!--/col-sm-6-->

				<div class="col-sm-6 wow fadeInRight animated">	
					<div class="phone-image">
						<img class="img-responsive" src="Content/front/img/2-iphone-right.png" alt="">
					</div>
				</div><!--/col-sm-6-->
			</div><!--/row-->
			
		</div><!--/container-->
	</section>


	<!-- ****************************** Gallery section ************************** -->
	<section id="gallery" class="block">
		<div class="container">

			<div class="title-box">
				<h1 class="block-title wow animated zoomIn">
					<span class="bb-top-left"></span>
					<span class="bb-bottom-left"></span>
					Screenshots
					<span class="bb-top-right"></span>
					<span class="bb-bottom-right"></span>
				</h1>
			</div>

			<div class="row">
				<div class="col-xs-12">
					<div id="screenshots" class="owl-carousel owl-theme">
					  <a href="Content/front/img/screenshots/1.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/1.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/2.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/2.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/3.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/3.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/4.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/4.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/1.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/1.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/2.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/2.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/3.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/3.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/4.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/4.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/1.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/1.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					  <a href="Content/front/img/screenshots/2.jpg" class="item" data-lightbox-gallery="screenshots">
					  	<img src="Content/front/img/screenshots/2.jpg" class="img_res wow animated zoomIn" alt="">
					  </a>
					</div>
					 <div class="customNavigation">
					  <a class="btn prev gallery-nav wow animated bounceInLeft"><i class="ion-ios-arrow-left"></i></a> 
					  <a class="btn next gallery-nav wow animated bounceInRight"><i class="ion-ios-arrow-right"></i></a>
					</div>
				</div>
			</div>
		</div>
	</section>


	<!-- ****************************** Testimonial ************************** -->
	<section id="testimonial" class="block">
		<div class="banner-overlay"></div>

		<div class="container">		
			<div id="review" class="owl-carousel owl-theme wow animated bounceInUp">
				<div class="item">
					<div class="row">
						<div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
							<div class="client-pic"><img class="img_res" src="Content/front/img/client-two.png" alt=""></div>
							<p class="review-star">
								<i class="ion-star"></i>
								<i class="ion-star"></i>
								<i class="ion-star"></i>
								<i class="ion-star"></i>
								<i class="ion-star-outline"></i>
							</p>
							<p class="review-desc">
								Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
								tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
								quis nostrud exercitation ullamco laboris nisi ut aliquip.
							</p>
							<p class="client-name">
								Shahjahan Jewel
							</p>
							<p class="client designation">CEO, Technext Inc.</p>
						</div>
					</div>
				</div>
				<div class="item">
					<div class="row">
						<div class="col-sm-6 col-md-offset-3">
							<div class="client-pic"><img class="img_res" src="Content/front/img/client-three.png" alt=""></div>
							<p class="review-star">
								<i class="ion-star"></i>
								<i class="ion-star"></i>
								<i class="ion-star"></i>
								<i class="ion-star"></i>
								<i class="ion-star-outline"></i>
							</p>
							<p class="review-desc">
								Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
								tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
								quis nostrud exercitation ullamco laboris nisi ut aliquip.
							</p>
							<p class="client-name">
								Jane Doe
							</p>
							<p class="client designation">CEO, Apple Inc.</p>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>


	<!-- ****************************** Team section ************************** -->
	<section id="team" class="block" runat="server" visible="false">
		<div class="container">
			<div class="title-box">
				<h1 class="block-title wow animated zoomIn">
					<span class="bb-top-left"></span>
					<span class="bb-bottom-left"></span>
					Development Team
					<span class="bb-top-right"></span>
					<span class="bb-bottom-right"></span>
				</h1>
			</div>
			<div class="row">
				<div class="col-md-3 col-sm-4 col-md-offset-1point5">
					<div class="team-member wow animated fadeIn" data-wow-delay="0.3s">
						<div class="border-img">
							<img src="Content/front/img/dev-2.jpg" class="img_res team-pic" alt="">
							<div class="border"></div>
						</div>
						<h2 class="wow animated fadeInDown" data-wow-delay="0.7s">Jhon Doe</h2>
						<p class="wow animated fadeIn" data-wow-delay="0.7s">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
						tempor incididunt ut labore et dolore magna aliqua.</p>
						<ul class="team-social">
							<li class="wow animated fadeInLeft facebook"><a href="#"><i class="ion-social-facebook"></i></a></li>
							<li class="wow animated fadeInLeft linkedin"><a href="#"><i class="ion-social-linkedin"></i></a></li>
							<li class="wow animated fadeInRight googleplus"><a href="#"><i class="ion-social-googleplus-outline"></i></a></li>
							<li class="wow animated fadeInRight github"><a href="#"><i class="ion-social-github"></i></a></li>
						</ul>
					</div>
				</div>

				<div class="col-md-3 col-sm-4">
					<div class="team-member wow animated fadeIn" data-wow-delay="0.3s">
						<div class="border-img">
							<img src="Content/front/img/dev-3.jpg" class="img_res team-pic" alt="">
							<div class="border"></div>
						</div>
						<h2 class="wow animated fadeInDown" data-wow-delay="0.7s">Jane Doe</h2>
						<p class="wow animated fadeIn" data-wow-delay="0.7s">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
						tempor incididunt ut labore et dolore magna aliqua.</p>
						<ul class="team-social">
							<li class="wow animated fadeInLeft facebook"><a href="#"><i class="ion-social-facebook"></i></a></li>
							<li class="wow animated fadeInLeft linkedin"><a href="#"><i class="ion-social-linkedin"></i></a></li>
							<li class="wow animated fadeInRight googleplus"><a href="#"><i class="ion-social-googleplus-outline"></i></a></li>
							<li class="wow animated fadeInRight github"><a href="#"><i class="ion-social-github"></i></a></li>
						</ul>
					</div>
				</div>

				<div class="col-md-3 col-sm-4">
					<div class="team-member wow animated fadeIn" data-wow-delay="0.3s">
						<div class="border-img">
							<img src="Content/front/img/dev-4.jpg" class="img_res team-pic" alt="">
							<div class="border"></div>
						</div>
						<h2 class="wow animated fadeInDown" data-wow-delay="0.7s">Jhon Doe</h2>
						<p class="wow animated fadeIn" data-wow-delay="0.7s">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
						tempor incididunt ut labore et dolore magna aliqua.</p>
						<ul class="team-social">
							<li class="wow animated fadeInLeft facebook"><a href="#"><i class="ion-social-facebook"></i></a></li>
							<li class="wow animated fadeInLeft linkedin"><a href="#"><i class="ion-social-linkedin"></i></a></li>
							<li class="wow animated fadeInRight googleplus"><a href="#"><i class="ion-social-googleplus-outline"></i></a></li>
							<li class="wow animated fadeInRight github"><a href="#"><i class="ion-social-github"></i></a></li>
						</ul>
					</div>
				</div>
			</div>
		</div>
	</section>


	<!-- ****************************** Pricing section ************************** -->
	<section id="pricing" class="block" runat="server" visible="false">
		<div class="banner-overlay bg-color-grad"></div>
		<div class="container">
			<div class="title-box">
				<h1 class="block-title title-light wow animated zoomIn">
					<span class="bb-top-left"></span>
					<span class="bb-bottom-left"></span>
					Affordable Packages
					<span class="bb-top-right"></span>
					<span class="bb-bottom-right"></span>
				</h1>
			</div>
			<div class="row">
				<div class="col-md-offset-2 col-md-8">
					<ul class="pricing-table">
						<li class="wow flipInY animated" style="visibility: visible;">
							<h3>Standard</h3>
							<span> $2.99 <small>per month</small> </span>
							<ul class="benefits-list">
								<li>Responsive</li>
								<li>Documentation</li>
								<li class="not">Multiplatform</li>
								<li class="not">Video background</li>
								<li class="not">Support</li>
							</ul>
							<a href="#" target="_blank" class="buy"><i class="ion-ios-cart-outline"></i></a>
						</li>
						<li class="gold wow flipInY animated" data-wow-delay="0.4s" style="visibility: visible;-webkit-animation-delay: 0.4s; -moz-animation-delay: 0.4s; animation-delay: 0.4s;">
							<div class="stamp"><i class="ion-android-star-outline"></i>Best choice</div>
							<h3>Gold</h3>
							<span> $7.99 <small>per month</small> </span>
							<ul class="benefits-list">
								<li>Responsive</li>
								<li>Documentation</li>
								<li>Multiplatform</li>
								<li>Video background</li>
								<li>Support</li>
							</ul>
							<a href="#" target="_blank" class="buy"> <i class="ion-ios-cart-outline"></i></a>
						</li>
						<li class="silver wow flipInY animated" data-wow-delay="0.2s" style="visibility: visible;-webkit-animation-delay: 0.2s; -moz-animation-delay: 0.2s; animation-delay: 0.2s;">
							<h3>Sliver</h3>
							<span> $4.99 <small>per month</small> </span>
							<ul class="benefits-list">
								<li>Responsive</li>
								<li>Documentation</li>
								<li>Multiplatform</li>
								<li class="not">Video background</li>
								<li class="not">Support</li>
							</ul> 
							<a href="#" target="_blank" class="buy"> <i class="ion-ios-cart-outline"></i></a>
						</li>
					</ul>
				</div>
			</div>
		</div>
	</section>

	
	<!-- ****************************** Subscribe section ************************** -->
	<section id="subscribe" class="block">
		<div class="banner-overlay" style="background: rgba(255, 255, 255, 0.8)"></div>
		<div class="container">
			<div class="row">
				<div class="col-sm-10 col-sm-offset-1">
					<p class="susbcribe-text">
					<strong>Subscribe to our email list to get the latest update about our amazing app</strong>
					<br/>Incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
					quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
					consequat.</p>
				</div>
			</div>
		</div>
		<div class="container subscribe-wrap">
			<div class="row">
				<div class="col-sm-12 wow animated bounceInUp">
					<form role="form" class="mailchimp">
						
						<div class="input-group">
						  <input type="email" name="email" id="subscriber-email" class="form-control" placeholder="Your Email Address">
						  <span class="input-group-btn">
						    <button class="btn btn-custom" type="submit" id="subscribe-button">GET UPDATES</button>
						  </span>
						</div><!-- /input-group -->

						<!-- SUCCESS OR ERROR MESSAGES -->			
						<span class="subscription-success"></span>
						<span class="subscription-error"></span>

					</form>
				</div>
			</div>
		</div>
	</section>


	<!-- ****************************** Contact section ************************** -->
	<section id="contact" class="block">
			<div class="container">
				<div class="title-box">
					<h1 class="block-title wow animated zoomIn">
						<span class="bb-top-left"></span>
						<span class="bb-bottom-left"></span>
							Contact Us
						<span class="bb-top-right"></span>
						<span class="bb-bottom-right"></span>
					</h1>
				</div>
				<div class="row">
					<div class="col-sm-4 address wow fadeInLeft animated">
						<ul class="address-list">
							<li><i class="ion-location"></i> <span>1537 Flint Street <br>Tumon, MP 96911</span></li>
							<li><i class="ion-android-call"></i> <span>670-898-2847 </span></li>
							<li><i class="ion-email"></i> <span>info@domain.com</span></li>
							<li><i class="ion-earth"></i> <span>www.themewagon.com</span></li>
						</ul>
					</div><!-- address -->
					<div class="col-sm-8 mailbox wow fadeInRight animated">
						<form name="sentMessage" id="contactForm" novalidate>
	                        <div class="row">
	                            <div class="col-md-6">
	                                <div class="form-group">
	                                    <input type="text" class="form-control" placeholder="Your Name *" id="name" required>
	                                    <p class="help-block text-danger"></p>
	                                </div>
	                                <div class="form-group">
	                                    <input type="email" class="form-control" placeholder="Your Email *" id="email" required data-validation-required-message="Please enter your email address.">
	                                    <p class="help-block text-danger"></p>
	                                </div>
	                                <div class="form-group">
	                                    <input type="text" class="form-control" placeholder="Your Subject *" id="subject" required data-validation-required-message="Please enter your phone number.">
	                                    <p class="help-block text-danger"></p>
	                                </div>
	                            </div>
	                            <div class="col-md-6">
	                                <div class="form-group">
	                                    <textarea class="form-control" placeholder="Your Message *" id="message" required data-validation-required-message="Please enter a message."></textarea>
	                                    <p class="help-block text-danger"></p>
	                                    <div id="success"></div>
		                                <button type="submit" class="polo-btn contact-submit"><i class="ion-paper-airplane"></i></button>
	                                </div>
	                            </div>
	                        </div>
	                        <div class="alert alert-danger error">Error!  E-mail must be valid and message must be longer than 1 character.</div>
	                        <div class="alert alert-success success">Your message has been sent successfully.</div>
	                    </form>
					</div><!--/send mail-->
				</div><!--/row-->
			</div>
			<div class="clearfix"></div>
	</section>


	<!-- ****************************** Footer ************************** -->
	<section id="footer" class="block">
		<div class="container text-center">
			<div class="footer-logo">
				<h1>L U C Y</h1>
			</div>
			<ul class="social-icons">
				<li class="wow animated fadeInLeft facebook"><a href="#"><i class="ion-social-facebook"></i></a></li>
				<li class="wow animated fadeInRight twitter"><a href="#"><i class="ion-social-twitter"></i></a>
				<li class="wow animated fadeInLeft linkedin"><a href="#"><i class="ion-social-linkedin"></i></a></li>
				<li class="wow animated fadeInRight googleplus"><a href="#"><i class="ion-social-googleplus-outline"></i></a></li>
				<li class="wow animated fadeInRight github"><a href="#"><i class="ion-social-github"></i></a>
			</ul>

			<div class="copyright">
				<div class="credits">
					Made With <i class="ion-heart"></i> by <a href="http://www.themewagon.com" target="_blank">ThemeWagon</a>
				</div>
				<div>©2015 Your Company, All Rights Reserved</div>
			</div>
		</div><!-- container -->
	</section>



	<!-- ****************************** Back to top ************************** -->
	<a id="back-to-top" href="#" class="btn btn-primary btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="glyphicon glyphicon-chevron-up"></span></a>



	<!-- All the scripts -->


        </form>
</body>
</html>
