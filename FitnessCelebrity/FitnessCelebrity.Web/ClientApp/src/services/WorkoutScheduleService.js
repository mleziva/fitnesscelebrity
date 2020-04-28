import HttpClient from "./HttpClient";
import { WorkoutScheduleRoutes } from "./ApiConstants";

export class WorkoutScheduleService {
  async update(fitnessPath) {
    const url = WorkoutScheduleRoutes.Update.replace("{id}", fitnessPath.id);
    const response = await HttpClient.put(url, fitnessPath.workouts);
  }
}

const service = new WorkoutScheduleService();

export default service;
