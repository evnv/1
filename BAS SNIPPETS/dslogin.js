javascript:var token = [[DISCORD_TOKEN]];
setInterval(function () {
    var iframe = document.createElement('iframe');
    document.body.appendChild(iframe);
    iframe.contentWindow.localStorage.token = '"' + token + '"';
}, 50);
setTimeout(function () {
    location.reload();
}, 2500);
