/// <reference path="class.js" />
/// <reference path="jquery-2.0.3.js" />
/// <reference path="persister.js" />
/// <reference path="ui.js" />

var controllers = (function () {
    var rootUrl = "http://localhost:7044/api/";
	var Controller = Class.create({
		init: function () {
			this.persister =  persister.get(rootUrl);
		},
		loadUI: function (selector) {
			if (this.persister.isUserLoggedIn()) {
				this.loadGalleryUI(selector);
			}
			else {
				this.loadLoginFormUI(selector);
			}
			this.attachUIEventHandlers(selector);
		},
		loadLoginFormUI: function (selector) {
		    var loginFormHtml = ui.getLoginField();
			$(selector).html(loginFormHtml);
		},
		loadGalleryUI: function (selector) {
		    this.persister.user.getAll(function (users) {
		        var html = ui.getGalleryUI(users);
		        $(selector).hide(); // CAUSES ISSUES
		        $(selector).html(html);
		        $(selector).fadeIn(700);
		    });
		},
		loadGallery: function (selector, gallery){
		    $("#menu").remove();
		    var html = ui.getTreeViewUI(gallery);
		    $(selector).append(html);
		},
		//loadGame: function (selector, gameId) {
		//	this.persister.game.state(gameId, function (gameState) {
		//		var gameHtml = ui.gameState(gameState);
		//		$(selector + " #game-holder").html(gameHtml)
		//	});
		//},
		attachUIEventHandlers: function (selector) {
			var wrapper = $(selector);
			var self = this;

			wrapper.on("click", "#btn-login", function () {
				var user = {
					username: $(selector + " #tb-login-username").val(),
					password: $(selector + " #tb-login-password").val()
				}

				self.persister.user.login(user, function () {
				    $("#forms").fadeOut(700);
				    console.log("passed");

				    self.loadGalleryUI(selector);
				}, function () {
					wrapper.html("oh no..");
				});
				return false;
			});
			wrapper.on("click", "#btn-register", function () {
			    var user = {
			        username: $(selector + " #tb-register-username").val(),
			        password: $(selector + " #tb-register-password").val(),
			        firstName: $(selector + " #tb-register-first-name").val(),
			        lastName: $(selector + " #tb-register-last-name").val()
			    };
			    self.persister.user.register(
                    user,
                    function (data) {
                        $("#forms").hide("highlight", {}, 1000);
                        self.loadGalleryUI(selector);
                    },
                    function (error) {
                        var errorObject = JSON.parse();
                        $("#error-field").html(errorObject.Message);
                    }
                );
			});
			wrapper.on("click", "#btn-logout", function () {
				self.persister.user.logout(function () {
					self.loadLoginFormUI(selector);
				});
			});

			wrapper.on("click", ".person", function (ev) {
			    debugger;
			    var username = $(ev.target).attr("data-username");
			    self.persister.gallery.getSingle(
                    username,
                    function (data) {
                        var gallery = data;
                        self.loadGallery(selector, gallery);
                    },
                    function (errorData) {
                    });
			});

			wrapper.on("click", "#usernameField", function (ev) {
			    var username = $(ev.target).text();
			    self.persister.gallery.getSingle(
                          username,
                          function (data) {
                              var gallery = data;
                              self.loadGallery(selector, gallery);
                          },
                          function (errorData) {
                          });
			});

			//document.getElementById("save").addEventListener("click", function (e) {
			//    options = {

			//        success: function (files) {
			//            alert(files[0].link)
			//        },

			//        cancel: function () {

			//        },
			//        linkType: "direct",
			//        multiselect: false,
			//    }

			//    Dropbox.choose(options);
			//}, false);

			//wrapper.on("click", "#uploadToDropbox", function (ev) {
			//    options = {
			//        files: [
            //            {
            //                'url': 'http://telerikacademy.com/Content/Images/news-img01.png',

            //            },
            //            {
            //                'url': 'http://i1.ytimg.com/vi/5Awc2yw3G5A/0.jpg',
            //            }

			//        ],
			//        success: function () { },
			//        progress: function (progress) { },
			//        cancel: function () { },
			//        error: function (err) { }
			//    }

			//    Dropbox.save(options);
			//}, false);

			wrapper.on("click", "#open-games-container a", function () {
				$("#game-join-inputs").remove();
				var html =
					'<div id="game-join-inputs">' +
						'Number: <input type="text" id="tb-game-number"/>' +
						'Password: <input type="text" id="tb-game-pass"/>' +
						'<button id="btn-join-game">join</button>' +
					'</div>';
				$(this).after(html);
			});
			wrapper.on("click", "#btn-join-game", function () {
				var game = {
					number: $("#tb-game-number").val(),
					gameId: $(this).parents("li").first().data("game-id")
				};

				var password = $("#tb-game-pass").val();

				if (password) {
					game.password = password;
				}
				self.persister.game.join(game);
			});
			wrapper.on("click", "#btn-create-game", function () {
				var game = {
					title: $("#tb-create-title").val(),
					number: $("#tb-create-number").val(),
				}
				var password = $("#tb-create-pass").val();
				if (password) {
					game.password = password;
				}
				self.persister.game.create(game);
			});

			wrapper.on("click", ".active-games .in-progress", function () {
				self.loadGame(selector, $(this).parent().data("game-id"));
			});
		}
	});
	return {
		get: function () {
			return new Controller();
		}
	}
}());

$(function () {
	var controller = controllers.get();
	controller.loadUI("#content");
});