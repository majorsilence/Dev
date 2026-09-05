(function(){
    // Hamburger menu toggle
    document.addEventListener('DOMContentLoaded', function() {
        var toggle = document.querySelector('.nav-toggle');
        var nav = document.getElementById('main-nav');
        if (!toggle || !nav) return;
        toggle.addEventListener('click', function() {
            var isOpen = nav.classList.toggle('is-open');
            toggle.setAttribute('aria-expanded', isOpen ? 'true' : 'false');
        });
    });
})();

(function(){
    // Theme switcher: wire up the <select> to the data-theme attribute
    // applied early (see inline script in <head>) to avoid a flash of the
    // wrong theme.
    document.addEventListener('DOMContentLoaded', function() {
        var select = document.getElementById('theme-select');
        if (!select) return;

        var stored = 'system';
        try {
            stored = window.localStorage.getItem('theme') || 'system';
        } catch (err) {}
        select.value = stored;

        select.addEventListener('change', function() {
            var theme = select.value;
            try {
                window.localStorage.setItem('theme', theme);
            } catch (err) {}
            if (theme === 'system') {
                document.documentElement.removeAttribute('data-theme');
            } else {
                document.documentElement.setAttribute('data-theme', theme);
            }
        });
    });
})();

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