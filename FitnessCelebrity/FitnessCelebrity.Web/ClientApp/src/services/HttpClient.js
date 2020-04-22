import authService from "../components/api-authorization/AuthorizeService";

export class HttpClient {
  async get(url) {
    const token = await authService.getAccessToken();
    return await fetch(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
  }
  async post(url, body) {
    const token = await authService.getAccessToken();
    return await fetch(url, {
      method: "POST",
      body: JSON.stringify(body),
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
  }
  async put(url, body) {
    const token = await authService.getAccessToken();
    return await fetch(url, {
      method: "PUT",
      body: JSON.stringify(body),
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
  }
}

const fetchClient = new HttpClient();

export default fetchClient;
