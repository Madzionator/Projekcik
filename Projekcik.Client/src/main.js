import App from './Components/App.svelte';

const app = new App({
	target: document.getElementById("app"),
	props: {
		name: 'dziczek 🐗😽🐻'
	}
});

export default app;