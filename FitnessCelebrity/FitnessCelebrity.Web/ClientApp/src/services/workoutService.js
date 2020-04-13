import authService from '../components/api-authorization/AuthorizeService'
import {WorkoutRoutes} from './ApiConstants'

export class WorkoutService {
    async createWorkout(workout) {
        const token = await authService.getAccessToken();
        const response = await fetch(WorkoutRoutes.CreateWorkout, {
            method: 'POST',
			body: JSON.stringify(workout),
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
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