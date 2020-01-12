# RunescapeToolkit

# TODOS
In many places (eg API.cs) I've made methods (and indeed, the entire class) public when they should really be private/protected (eg BuildHighscoresUrl()) - this is to allow testing - I know this is the wrong way to resolve this, and I shouldn't be unit testing private funcs, and these shouldn't be private funcs... here we are though...In many places (eg API.cs) I've made methods (and indeed, the entire class) public when they should really be private/protected (eg BuildHighscoresUrl()) - this is to allow testing - I know this is the wrong way to resolve this, and I shouldn't be unit testing private funcs, and these shouldn't be private funcs... here we are though...

Regarding the above, I should probs use some kind of Mock, to create intergration tests for these, instead of making everything public, and testing behind the scenes that way?
