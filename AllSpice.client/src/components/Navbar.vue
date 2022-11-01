<template class="container">
  <nav
    class="navbar navbar-expand-lg navbar px-3 mt-3 d-flex flex-wrap justify-content-end align-items-start mx-2"
    :style="{
      backgroundImage: `url('https://s3-alpha-sig.figma.com/img/137d/d14c/aa93e0df14a805e8e10c9f1221ba5131?Expires=1668384000&Signature=clbuQxAqhFfk7Z9DXFb-1Tn1rH~Sb-ZUoeiSthGI1hQU4KOFsbQWpuVGSDPI6mldDhxN0jsICnS~flF4CAgTZJyWIL71y2OZSBMsJLOLdbZ4yswOBHJbiXDdVmvTpkynW8ncsteX99uhT7OcqqeSVeg1mRi818v3cBmCIlApMJxR74pqc07dRAlao4FB9xDdWQ4SBqiM9mzR6EuOhqzoNO0mOM1zqTIU2Per9KOy3Ly4R6WRJggihPNv0jtzM6hw5cv~Xq8MncZWyMvOJKTvq520TwNzON6gIviz7UTWwXzrQFGHdnnbFCKDB7C54oDcRjMnvyMrLyPfDEDnseEUDg__&Key-Pair-Id=APKAINTVSUGEWH5XD5UA')`,
    }"
  >
    <div class="col-md-12 d-flex justify-content-end">
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarText"
        aria-controls="navbarText"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <!-- Search Bar Goes Here -->
      <div class="collapse navbar-collapse" id="navbarText">
        <!-- LOGIN COMPONENT HERE -->
        <Login />
      </div>
    </div>
    <div class="col-md-12 text-center">
      <h1 class="text-light">All Spice</h1>
    </div>
    <div class="col-md-12 text-center text-light">
      <h4>Cherish Your Family and Their Cooking</h4>
    </div>
    <div class="col-md-12">
      <div class="row justify-content-center">
        <div class="col-md-6 categories">
          <div class="card card-body d-flex">
            <div class="d-flex justify-content-around">
              <button class="btn btn-outline-success">
                <h6>Home</h6>
              </button>
              <button class="btn btn-outline-success">
                <h6>My Recipes</h6>
              </button>
              <button class="btn btn-outline-success">
                <h6>Favorites</h6>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import Login from "./Login.vue";
export default {
  setup() {
    return {};
  },
  components: { Login },
};
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 200px;
  }
}
</style>
