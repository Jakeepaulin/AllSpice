<template>
  <header>
    <section class="container-fluid">
      <div class="row mt-5">
        <RecipeCard v-for="r in recipes" :key="r.id" :recipe="r" />
      </div>
    </section>
  </header>
  <body></body>
</template>

<script>
import { computed, onMounted, ref } from "vue";
import { AppState } from "../AppState.js";
import RecipeCard from "../components/RecipeCard.vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({});
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      getRecipes();
    });
    return {
      editable,
      recipes: computed(() => AppState.recipes),
    };
  },
  components: { RecipeCard },
};
</script>

<style scoped lang="scss">
.image-height {
  height: 15vh;
  overflow: hidden;
  object-fit: cover;
  object-position: center;
}
</style>
