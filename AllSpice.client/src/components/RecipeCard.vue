<template>
  <div class="col-md-4 my-3">
    <div
      class="card elevation-1"
      :style="{
        backgroundImage: `url(${recipe.img}) `,
      }"
    >
      <div class="card-header">
        <div class="col-md-2">
          <h6>{{ recipe.category }}</h6>
        </div>
        <div class="card-body">
          <div></div>
        </div>
      </div>
      <div class="card-footer">
        <h4 class="card-title">{{ recipe.title }}</h4>
        <p class="card-text">{{ recipe.description }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import { Recipe } from "../models/Recipe.js";

export default {
  props: {
    recipe: { type: Recipe, required: true },
  },
  setup() {
    return {};
  },
};
</script>

<style lang="scss" scoped></style>
