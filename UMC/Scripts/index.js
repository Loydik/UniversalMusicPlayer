$(document).ready(function() {
    $('#range-val').on("change mousemove", function() {
        var original_time = $(this).val();
        var new_time = formatSeconds(original_time);
        $("#time p").text(new_time);
    });

    var r = document.getElementById('range-val');
    var max = r.getAttribute('max');
    var min = r.getAttribute('min');
    var w = r.clientWidth;
    //w += r.offsetLeft;
    var isDragging = false;

    var moveTip = (function(e) {
        if (isDragging) {
            var posPerc = (r.value / max) * 100;
            var pixPos = (posPerc / 100) * w - 40;
            /* pixPos += r.offsetLeft;*/

            document.getElementById('music-player-range-tip').style.display = 'block';
            document.getElementById('music-player-range-tip').style.left = pixPos + 'px';
        }
    });

    $("#range-val").mousemove(function() {
        isDragging = true;
        var range_val = document.getElementById("range-val").value;
        document.getElementById('music-player-range-tip').innerHTML = formatSeconds(range_val);
        r.addEventListener('mousemove', moveTip, false);
    });

    $("body").mouseup(function(e) {
        isDragging = false;
        r.removeEventListener('mousemove', moveTip);
        document.getElementById('music-player-range-tip').style.display = 'none';
    });

    $("fa-pause").click(function() {
        alert("Clicked!");
    });
});

function formatSeconds(seconds) {
    var date = new Date(1970, 0, 1);
    date.setSeconds(seconds);
    return date.toTimeString().replace(/.*(\d{2}:\d{2}).*/, "$1");
}