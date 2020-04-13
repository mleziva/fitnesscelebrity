const prefix = '/api';
const fitnessPathController = 'FitnessPath'
const workoutController = 'Workout'
const ProfileController = 'UserProfile'

export const FitnessPathRoutes = {
  ListForUser: `${prefix}/${fitnessPathController}/user/list`,
  GetById: `${prefix}/${fitnessPathController}/`,
  Search: `${prefix}/${fitnessPathController}/search`,
};

export const WorkoutRoutes = {
    CreateWorkout: `${prefix}/${workoutController}`,
  };

export const ProfileRoutes = {
  GetProfile: `${prefix}/${ProfileController}/username/`,
};
  
