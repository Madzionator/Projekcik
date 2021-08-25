import { writable } from "svelte/store";

const authTokenKey = "auth_token";

export const token = writable(localStorage.getItem(authTokenKey));
