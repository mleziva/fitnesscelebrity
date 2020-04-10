const prefix = '/api';
const fitnessPathController = 'FitnessPath'
const workoutController = 'Workout'

export const FitnessPathRoutes = {
  ListForUser: `${prefix}/${fitnessPathController}/user/list`,
};

export const WorkoutRoutes = {
    CreateWorkout: `${prefix}/${workoutController}`,
  };
  
