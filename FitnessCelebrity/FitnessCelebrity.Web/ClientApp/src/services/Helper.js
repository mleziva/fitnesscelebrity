export class Helper {
  buildQueryString(params) {
    var query = [];
    for (var key in params) {
      if (params.hasOwnProperty(key)) {
        query.push(
          encodeURIComponent(key) + "=" + encodeURIComponent(params[key])
        );
      }
    }
    let querystring = "?" + query.join("&");
    return querystring;
  }
  setQueryStringWithoutPageReload(qsObject) {
    let qsValue = this.buildQueryString(qsObject);
    const newurl =
      window.location.protocol +
      "//" +
      window.location.host +
      window.location.pathname +
      qsValue;

    window.history.pushState({ path: newurl }, "", newurl);
  }
  queryToObject(qstring) {
    var i = 0,
      retObj = {},
      pair = null,
      sPageURL = qstring.substring(1),
      qArr = sPageURL.split("&");
    for (i = 0; i < qArr.length; i++) {
      pair = qArr[i].split("=");
      retObj[pair[0]] = pair[1];
    }

    return retObj;
  }
  getLocalISOTime() {
    var tzoffset = new Date().getTimezoneOffset() * 60000; //offset in milliseconds
    var localISOTime = new Date(Date.now() - tzoffset)
      .toISOString()
      .slice(0, -1);
    return localISOTime;
  }
}
const helper = new Helper();
export default helper;
