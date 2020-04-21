import authService from "../components/api-authorization/AuthorizeService";
import { MovementRoutes } from "./ApiConstants";

export class MovementService {
  async get() {
    const url = MovementRoutes.Get;
    const token = await authService.getAccessToken();
    const response = await fetch(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    return await response.json();
  }
  async getById(id) {
    const url = MovementRoutes.GetById + id;
    const token = await authService.getAccessToken();
    const response = await fetch(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    return await response.json();
  }
  async search(query) {
    const url = MovementRoutes.Search + "?query=" + query;
    const token = await authService.getAccessToken();
    const response = await fetch(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    return await response.json();
  }
}

const movementService = new MovementService();

export default movementService;
