import HttpClient from "./HttpClient";
import { WorkoutHistoryRoutes } from "./ApiConstants";

export class WorkoutHistoryService {
  async startWorkout(workoutHistory) {
    const url = WorkoutHistoryRoutes.Create;
    workoutHistory.startedDate = new Date();
    const response = await HttpClient.post(url, workoutHistory);
  }
  async finishWorkout(workoutHistory) {
    const url = WorkoutHistoryRoutes.Create;
    workoutHistory.completedDate = new Date();
    const response = await HttpClient.post(url, workoutHistory);
  }
}

const service = new WorkoutHistoryService();

export default service;
