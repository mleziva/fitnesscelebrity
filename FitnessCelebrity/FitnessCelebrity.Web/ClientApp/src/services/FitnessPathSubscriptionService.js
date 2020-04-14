import authService from '../components/api-authorization/AuthorizeService'
import {FitSubscriptionRoutes} from './ApiConstants'

export class FitnessPathSubscriptionService {
    async create(fitnessPathId) {
        const token = await authService.getAccessToken();
        const response = await fetch(FitSubscriptionRoutes.CreateSubscription, {
            method: 'POST',
			body: JSON.stringify(fitnessPathId),
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        });
        //do some error handling/logging
        if (!response.ok) {
            console.log(await response.json());  
          }
         //return ok or something
    }
}

const fitnessPathSubscriptionService = new FitnessPathSubscriptionService();

export default fitnessPathSubscriptionService;