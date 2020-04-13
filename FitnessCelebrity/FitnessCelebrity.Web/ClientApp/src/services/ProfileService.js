import authService from '../components/api-authorization/AuthorizeService'
import {ProfileRoutes} from './ApiConstants'

export class ProfileService {
    async getProfile(username) {
        const url = ProfileRoutes.GetProfile +  username;
        const token = await authService.getAccessToken();
        const response = await fetch(url, {
            method: 'GET',
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        });
        return await response.json();
         
        //const data = await response.json();
    }
}

const profileService = new ProfileService();

export default profileService;