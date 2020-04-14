
export const Helper = {
    buildQueryString(params) {
        var query = [];
        for (var key in params) {
            if (params.hasOwnProperty(key)) {
                query.push(encodeURIComponent(key) + '=' + encodeURIComponent(params[key]));
            }
        }
        let querystring = "?" + query.join('&');
        return querystring;
    }
}