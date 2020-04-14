const prefix = '/api';
const fitnessPathController = 'FitnessPath'
const fitSubscriptionController = 'FitnessPathSubscription'
const workoutController = 'Workout'
const ProfileController = 'UserProfile'

export const FitnessPathRoutes = {
  Get: `${prefix}/${fitnessPathController}/`,
  GetById: `${prefix}/${fitnessPathController}/`,
  Search: `${prefix}/${fitnessPathController}/search`,
};

export const WorkoutRoutes = {
    CreateWorkout: `${prefix}/${workoutController}`,
  };

export const ProfileRoutes = {
  GetProfile: `${prefix}/${ProfileController}/username/`,
};

export const FitSubscriptionRoutes = {
  CreateSubscription: `${prefix}/${fitSubscriptionController}/`,
};
  
