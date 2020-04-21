import authService from "../components/api-authorization/AuthorizeService";
import { FitnessPathRoutes } from "./ApiConstants";
import Helper from "./Helper";

export class FitnessPathService {
  //returns an array of top 50 fitness paths
  async get(params) {
    const url = FitnessPathRoutes.Get + Helper.buildQueryString(params);
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
    const url = FitnessPathRoutes.GetById + id;
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
    const url = FitnessPathRoutes.Search + "?query=" + query;
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
  //todo add paging
  async getSubscribedPaths(userId, params) {
    const url =
      FitnessPathRoutes.GetSubscribedPaths.replace("{userid}", userId) +
      Helper.buildQueryString(params);
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
  async getSubscribers(fitnessPathId) {
    const url = FitnessPathRoutes.GetSubscribers.replace(
      "{fitnesspathid}",
      fitnessPathId
    );
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
  async update(fitnessPath) {
    const url = FitnessPathRoutes.Update.replace(
      "{fitnesspathid}",
      fitnessPath.id
    );
    const token = await authService.getAccessToken();
    const response = await fetch(url, {
      method: "PUT",
      body: JSON.stringify(fitnessPath),
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
  }
  async updateLinkedWorkouts(fitnessPath) {
    const url = FitnessPathRoutes.UpdateWorkouts.replace(
      "{fitnesspathid}",
      fitnessPath.id
    );
    const token = await authService.getAccessToken();
    const response = await fetch(url, {
      method: "PUT",
      body: JSON.stringify(fitnessPath),
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
  }
  async create(fitnessPath) {
    const url = FitnessPathRoutes.Create;
    const token = await authService.getAccessToken();
    const response = await fetch(url, {
      method: "POST",
      body: JSON.stringify(fitnessPath),
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    return await response.json();
  }
}

const fpService = new FitnessPathService();

export default fpService;
