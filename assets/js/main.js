(function(){
    // Intercept same-origin navigations and use the View Transitions API
    // Graceful fallback: if API unavailable, navigation proceeds normally
    if (!('startViewTransition' in document)) return;

    document.addEventListener('click', function (e) {
        const anchor = e.target.closest && e.target.closest('a');
        if (!anchor) return;

        // Ignore when user intends a new tab / special click
        if (anchor.target && anchor.target !== '_self') return;
        if (e.metaKey || e.ctrlKey || e.shiftKey || e.altKey) return;

        let url;
        try {
            url = new URL(anchor.href, location.href);
        } catch (err) {
            return;
        }

        // Only same-origin navigations
        if (url.origin !== location.origin) return;

        // Let hash-only navigation behave normally (in-page anchors)
        if (url.pathname === location.pathname && url.search === location.search) return;

        // Prevent full navigation and run the view transition
        e.preventDefault();
        document.startViewTransition(() => {
            location.href = url.href;
        });
    }, {capture: true});
})();