<script>
  import { Router, Link, Route } from "svelte-navigator";
  import Home from "./Pages/Home.svelte";
  import Witam from "./Pages/Witam.svelte";
  import Pozdrawiam from "./Pages/Pozdrawiam.svelte";
  import HelloWorld from "./Components/HelloWorld.svelte";
  import Error from "./Pages/Error.svelte";
  import Header from "./Components/Header.svelte";
</script>

<Router>
  <Header />
  <div>
    <Route path="/" component={Home} />
    <Route path="witam" component={Witam} />
    <Route path="pozdrawiam" component={Pozdrawiam} />
    <Route path="helloworld" component={HelloWorld} />
    <Route component={Error} />
  </div>
</Router>
