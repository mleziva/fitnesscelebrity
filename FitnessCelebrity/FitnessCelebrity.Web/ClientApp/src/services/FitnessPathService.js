import authService from '../components/api-authorization/AuthorizeService'
import {FitnessPathRoutes} from './ApiConstants'

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

    async getById(id) {
        const url = FitnessPathRoutes.GetById + id;
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
        const url = FitnessPathRoutes.Search +"?query=" + query;
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
}

const fpService = new FitnessPathService();

export default fpService;