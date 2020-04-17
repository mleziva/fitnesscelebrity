import authService from '../components/api-authorization/AuthorizeService'
import {WorkoutRoutes} from './ApiConstants'

export class WorkoutService {

    async getMyCreatedWorkouts() {
        const url = WorkoutRoutes.Get +"?UserId=677f3748-0249-45ce-8979-9b7eda98c668";
        const token = await authService.getAccessToken();
        const response = await fetch(url, {
            method: 'GET',
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        });
        return await response.json();
    }
    async getById(id) {
        const url = WorkoutRoutes.GetById + id;
        const token = await authService.getAccessToken();
        const response = await fetch(url, {
            method: 'GET',
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        });
        return await response.json();
    }

    async search(query) {
        const url = WorkoutRoutes.Search +"?query=" + query;
        const token = await authService.getAccessToken();
        const response = await fetch(url, {
            method: 'GET',
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        });
        return await response.json();
    }


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