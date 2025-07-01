
    document.addEventListener('contextmenu', function (e) {
        e.preventDefault();
    });

    document.addEventListener('copy', function (e) {
        e.preventDefault();
    alert("Copying content is disabled on this page.");
    });
