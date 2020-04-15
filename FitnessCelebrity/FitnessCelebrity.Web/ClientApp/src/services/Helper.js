
export class Helper {
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
    setQueryStringWithoutPageReload(qsObject){ 
        let qsValue = this.buildQueryString(qsObject);
        const newurl = window.location.protocol + "//"+
                       window.location.host + 
                       window.location.pathname + 
                       qsValue;
     
        window.history.pushState({ path: newurl }, "", newurl);
    }
    queryToObject(qstring){
        var
        i = 0,
        retObj = {},
        pair = null,
        sPageURL = qstring.substring(1),
        qArr = sPageURL.split('&');
        for (i=0; i< qArr.length; i++){
            pair = qArr[i].split('=');
            retObj[pair[0]] = pair[1];
        };
     
        return retObj;
    };
     
}
const helper = new Helper();
export default helper;