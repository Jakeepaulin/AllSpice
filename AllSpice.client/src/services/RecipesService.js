import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";

class RecipesService {
  async getRecipes(category = "") {
    let res;
    if (category) {
      res = await api.get("api/recipes", {
        params: {
          category: category,
        },
      });
    } else {
      res = await api.get("api/recipes");
      console.log(res.data);
    }
    AppState.recipes = res.data.map((r) => new Recipe(r));
  }
}

export const recipesService = new RecipesService();
