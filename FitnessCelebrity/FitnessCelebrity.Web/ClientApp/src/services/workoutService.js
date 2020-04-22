import authService from "../components/api-authorization/AuthorizeService";
import { WorkoutRoutes } from "./ApiConstants";
import HttpClient from "./HttpClient";

export class WorkoutService {
  async get() {
    const url = WorkoutRoutes.Get;
    const response = await HttpClient.get(url);
    return await response.json();
  }
  async getMyCreatedWorkouts() {
    const url =
      WorkoutRoutes.Get + "?UserId=" + (await authService.getSubClaim());
    const response = await HttpClient.get(url);
    return await response.json();
  }
  async getById(id) {
    const url = WorkoutRoutes.GetById + id;
    const response = await HttpClient.get(url);
    return await response.json();
  }

  async search(query) {
    const url = WorkoutRoutes.Search + "?query=" + query;
    const response = await HttpClient.get(url);
    return await response.json();
  }
  async update(workout) {
    const url = WorkoutRoutes.Update.replace("{workoutId}", workout.id);
    const response = await HttpClient.put(url, workout);
  }
  async updateLinkedMovements(workout) {
    const url = WorkoutRoutes.UpdateMovements.replace(
      "{workoutId}",
      workout.id
    );
    const response = await HttpClient.put(url, workout);
  }
  async create(workout) {
    const url = WorkoutRoutes.Create;
    const response = await HttpClient.post(url, workout);
    return await response.json();
  }

  async createWorkout(workout) {
    const token = await authService.getAccessToken();
    const response = await fetch(WorkoutRoutes.CreateWorkout, {
      method: "POST",
      body: JSON.stringify(workout),
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });
    //do some error handling/logging
    if (!response.ok) {
      console.log(workout);
      console.log(JSON.stringify(workout));
      console.log(await response.json());
    }

    //const data = await response.json();
  }
}

const workoutService = new WorkoutService();

export default workoutService;
