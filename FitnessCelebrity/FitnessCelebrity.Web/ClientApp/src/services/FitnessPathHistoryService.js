import { FitnessPathHistoryRoutes } from "./ApiConstants";
import HttpClient from "./HttpClient";
import Helper from "./Helper";
import authService from "../components/api-authorization/AuthorizeService";
import { HistoryStateEnum } from "../app/const/EnumConfig";

export class FitnessPathHistoryService {
  async getMyCurrentlyActive() {
    var userId = await authService.getSubClaim();
    var stateObj = HistoryStateEnum.find((o) => o.name === "Active");
    var params = { userid: userId, state: stateObj.id };
    const url = FitnessPathHistoryRoutes.Get + Helper.buildQueryString(params);
    const response = await HttpClient.get(url);
    return await response.json();
  }

  async create(fpHistory) {
    const url = FitnessPathHistoryRoutes.Create;
    const responseJson = await HttpClient.post(url, fpHistory);
    return responseJson;
  }
  async activateFitnessPath(fitnessPathId) {
    var userId = await authService.getSubClaim();
    var stateObj = HistoryStateEnum.find((o) => o.name === "Active");
    var fpHistory = {
      fitnessPathId: fitnessPathId,
      userId: userId,
      privacy: 0,
      state: stateObj.id,
      notes: null,
      startedDate: "2020-05-04T16:55:23.725Z",
      completedDate: "2020-05-04T16:55:23.725Z",
    };
    return await this.create(fpHistory);
  }
}

const fpService = new FitnessPathHistoryService();

export default fpService;
