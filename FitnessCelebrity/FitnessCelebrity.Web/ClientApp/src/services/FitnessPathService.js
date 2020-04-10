import authService from '../../api-authorization/AuthorizeService'
import {FitnessPathRoutes} from '../WorkoutApiConstants'

export class FitnessPathService {

    //returns an array of top 50 fitness paths 
    async listUserFitnessPaths() {
        const token = await authService.getAccessToken();
        const response = await fetch(FitnessPathRoutes.ListForUser, {
            method: 'GET',
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        });
        return await response.json();
    }
}

const fpService = new FitnessPathService();

export default fpService;