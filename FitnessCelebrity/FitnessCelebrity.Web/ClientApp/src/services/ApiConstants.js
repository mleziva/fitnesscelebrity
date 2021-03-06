const prefix = "/api";
const fitnessPathController = "FitnessPath";
const fitSubscriptionController = "FitnessPathSubscription";
const workoutController = "Workout";
const ProfileController = "UserProfile";
const MovementController = "Movement";

export const FitnessPathRoutes = {
  Get: `${prefix}/${fitnessPathController}/`,
  Create: `${prefix}/${fitnessPathController}/`,
  GetById: `${prefix}/${fitnessPathController}/`,
  Search: `${prefix}/${fitnessPathController}/search`,
  GetSubscribers: `${prefix}/${fitnessPathController}/{fitnesspathid}/subscribers`,
  GetSubscribedPaths: `${prefix}/${fitnessPathController}/subscription/{userid}`,
  Update: `${prefix}/${fitnessPathController}/{fitnesspathid}`,
  UpdateWorkouts: `${prefix}/${fitnessPathController}/{fitnesspathid}/workouts`,
};

export const WorkoutRoutes = {
  CreateWorkout: `${prefix}/${workoutController}`,
  GetById: `${prefix}/${workoutController}/`,
  Get: `${prefix}/${workoutController}/`,
  Create: `${prefix}/${workoutController}/`,
  Update: `${prefix}/${workoutController}/{workoutId}`,
  UpdateMovements: `${prefix}/${workoutController}/{workoutId}/movements/`,
  UpdateFitnessPaths: `${prefix}/${workoutController}/{workoutId}/fitnessPaths/`,
  Search: `${prefix}/${workoutController}/search`,
};

export const ProfileRoutes = {
  GetProfile: `${prefix}/${ProfileController}/username/`,
};

export const FitSubscriptionRoutes = {
  CreateSubscription: `${prefix}/${fitSubscriptionController}/`,
};

export const MovementRoutes = {
  GetById: `${prefix}/${MovementController}/`,
  Get: `${prefix}/${MovementController}/`,
  Create: `${prefix}/${MovementController}/`,
  Update: `${prefix}/${MovementController}/{movementId}`,
  UpdateWorkouts: `${prefix}/${MovementController}/{movementId}/workouts/`,
  Search: `${prefix}/${MovementController}/search`,
};

export const WorkoutScheduleRoutes = {
  Update: "/api/FitnessPathWorkout/fitnessPath/{id}/workouts",
};
export const FitnessPathHistoryRoutes = {
  Create: "/api/FitnessPathHistory/",
  Get: "/api/FitnessPathHistory/",
};
export const WorkoutHistoryRoutes = {
  Create: "/api/WorkoutHistory/",
  Get: "/api/WorkoutHistory/",
};
