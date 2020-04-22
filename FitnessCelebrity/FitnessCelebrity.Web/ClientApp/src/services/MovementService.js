import { MovementRoutes } from "./ApiConstants";
import HttpClient from "./HttpClient";
import authService from "../components/api-authorization/AuthorizeService";

export class MovementService {
  async get() {
    const url = MovementRoutes.Get;
    const response = await HttpClient.get(url);
    return await response.json();
  }
  async getMyCreatedMovements() {
    const url =
      MovementRoutes.Get + "?UserId=" + (await authService.getSubClaim());
    const response = await HttpClient.get(url);
    return await response.json();
  }
  async getById(id) {
    const url = MovementRoutes.GetById + id;
    const response = await HttpClient.get(url);
    return await response.json();
  }
  async search(query) {
    const url = MovementRoutes.Search + "?query=" + query;
    const response = await HttpClient.get(url);
    return await response.json();
  }
  async update(movement) {
    const url = MovementRoutes.Update.replace("{movementId}", movement.id);
    const response = await HttpClient.put(url, movement);
  }
  async updateLinkedWorkouts(movement) {
    const url = MovementRoutes.UpdateWorkouts.replace(
      "{movementId}",
      movement.id
    );
    const response = await HttpClient.put(url, movement);
  }
  async create(movement) {
    const url = MovementRoutes.Create;
    const response = await HttpClient.post(url, movement);
    return await response.json();
  }
}

const movementService = new MovementService();

export default movementService;
