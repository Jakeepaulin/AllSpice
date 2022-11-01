export class Favorite {
  constructor(data) {
    this.id = data.id;
    this.accountId = data.accountId;
    this.recipeId = data.recipeId;
    this.createdAt = data.createdAt;
    this.updatedAt = data.updatedAt;
  }
}
