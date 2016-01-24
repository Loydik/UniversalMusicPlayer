//// initialize soundcloud API with key
//SC.initialize({
//    // This is the sample client_id. you should replace this with your own
//    client_id: "77dbaa2be42c37e39251326aad765645"
//});

//// DOM elements
//var artwork = $("#artwork");


//// Getting SC track infos
////function playTrack(trackId) {

////    SC.get('/tracks/' + trackId, function(track) {

////        // Injecting infos
////        artwork.attr('src', track.artwork_url.replace('-large', '-crop')); // Cover (replacing the default image size "large" with "crop")

////        // Play btn
////        var status = false; // play status

////        $('#play').click(function(e) {
////            e.preventDefault();

////            if (status == false) {

////                $('#player').addClass('open'); // Opening the player
////                //$('#record').addClass('spinning'); // vinyl now spinning

////                //$(this).removeClass('ion-ios7-play').addClass('ion-ios7-pause'); // change play btn to pause btn

////                $(this).removeClass('fa fa-play-circle').addClass('fa fa-pause'); // change play btn to pause btn

////                window.audioPlayer = new Audio(track.uri + '/stream?client_id=' + window.clientId); // Create audio object with stream url...
////                window.audioPlayer.play(); // ...and play

////                status = !status; // invert player status  
////            }

////            else {

////                $('#player').removeClass('open'); // Closing the player
////                $('#record').removeClass('spinning'); // vinyl stopped spinning
////                //$(this).removeClass('ion-ios7-pause').addClass('ion-ios7-play'); // change pause btn to play btn

////                $(this).removeClass('fa fa-pause').addClass('fa fa-play-circle'); // change pause btn to play btn

////                window.audioPlayer.pause(); // Pause the player
////                status = !status; // invert status
////            }


////        });

////    });
////}



//function playSoundcloudTrack(trackId) {

//    // Play btn
//    var status = false; // play status

//    SC.stream("/tracks/" + trackId).then(function(player) {

//        if (status === false) {
//            player.play();

//            // Injecting infos
//            artwork.attr('src', track.artwork_url.replace('-large', '-crop')); // Cover (replacing the default image size "large" with "crop")

//            $("#music-player-song-title").html("Playing");

//            $(this).removeClass('fa fa-play-circle').addClass('fa fa-pause'); // change play btn to pause btn
//            status = !status;

//        } else {

//            player.pause();

//            $("#track-play-button").removeClass("fa-pause");
//            $("#track-play-button").addClass("fa-play-circle");
//            status = !status; // invert status
//        }
//    });
//}

////function pauseSoundcloudTrack(trackId) {
////    SC.stream("/tracks/" + trackId).then(function (player) {
////        player.pause();
////        trackState = "paused";

////        $("#track-play-button").show();
////        $("#track-pause-button").hide();
////    });
////}


$("#music-collection").scPlayer({
    continuePlayback: true
});