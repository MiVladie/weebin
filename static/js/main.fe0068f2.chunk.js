(this.webpackJsonpjolie=this.webpackJsonpjolie||[]).push([[0],{10:function(A,g,B){A.exports={Layout:"Layout_Layout__3J4uI",Background:"Layout_Background__2g4Zm",Play:"Layout_Play__3hwu3",Content:"Layout_Content__2GFqd"}},12:function(A,g,B){A.exports={Holder:"Slider_Holder__13EOi",Image:"Slider_Image__3-XFu",Active:"Slider_Active__Hem_h"}},13:function(A,g,B){A.exports={Back:"Game_Back__1pJ4h",Main:"Game_Main__38Inc",Loading:"Game_Loading__m-R4D"}},19:function(A,g,B){A.exports={Button:"Button_Button__3gsF7"}},27:function(A,g,B){},34:function(A,g,B){"use strict";B.r(g);var C=B(16),Q=B.n(C),e=B(9),t=B(0),I=B(2),a=B(7),n=B(10),c=B.n(n),E=(B(27),B(1)),i=function(A){var g=A.children,B=Object(I.e)();return Object(E.jsxs)("div",{className:c.a.Layout,children:[Object(E.jsx)("div",{className:[c.a.Background,"/play"===B.pathname?c.a.Play:""].join(" ")}),Object(E.jsx)("div",{className:c.a.Content,children:g})]})},s=function(){return[/Android/i,/webOS/i,/iPhone/i,/iPad/i,/iPod/i,/BlackBerry/i,/Windows Phone/i].some((function(A){return navigator.userAgent.match(A)}))},o=function(A){var g=arguments.length>1&&void 0!==arguments[1]&&arguments[1];g?window.open(A,"_blank","noopener,noreferrer"):window.location.href=A},j=B(19),w=B.n(j),r=function(A){var g=A.children,B=A.onClick,C=A.className,Q=A.disabled;return Object(E.jsxs)("button",{className:[w.a.Button,C].join(" "),onClick:B,disabled:Q,children:[Object(E.jsx)("img",{src:"data:image/png;base64,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",alt:"button"}),Object(E.jsx)("p",{children:g})]})},D=B(5),b=B(12),G=B.n(b),u=function(A){var g=A.data,B=A.time,C=void 0===B?6:B,Q=A.delay,e=void 0===Q?0:Q,I=A.className,a=Object(t.useState)(!e),n=Object(D.a)(a,2),c=n[0],i=n[1],s=Object(t.useState)(0),o=Object(D.a)(s,2),j=o[0],w=o[1];Object(t.useEffect)((function(){var A;return 0!==e&&(A=setTimeout((function(){i(!0),w(j+1)}),1e3*e)),function(){return clearTimeout(A)}}),[]),Object(t.useEffect)((function(){if(c){var A=setInterval((function(){r()}),1e3*C);return function(){return clearInterval(A)}}}),[j]);var r=function(){c||i(!0),j!==g.length-1?w(j+1):w(0)};return Object(E.jsx)("div",{className:[G.a.Holder,I].join(" "),children:g.map((function(A,g){return Object(E.jsx)("img",{className:[G.a.Image,j===g?G.a.Active:""].join(" "),src:A,alt:"screenshot"},g)}))})},M=B.p+"static/media/logo.74eb237d.png",d=B.p+"static/media/hetimiul_1.2c6772aa.png",O=B.p+"static/media/hetimiul_2.cf2635d1.png",l=B.p+"static/media/hetimiul_3.e2f828de.png",k=B.p+"static/media/cisius_1.ddd7822a.png",m=B.p+"static/media/cisius_2.0cc07146.png",x=B.p+"static/media/cisius_3.3c970e9e.png",h=B.p+"static/media/juseno_1.d081e69d.png",f=B.p+"static/media/juseno_2.98345a8b.png",N=B.p+"static/media/juseno_3.5a74353a.png",L=B(6),Y=B.n(L),P=function(){var A=Object(I.f)();return Object(E.jsxs)(E.Fragment,{children:[Object(E.jsx)(a.a,{children:Object(E.jsx)("title",{children:"Home | Weebin"})}),Object(E.jsxs)("div",{className:Y.a.Main,children:[Object(E.jsx)("img",{className:Y.a.Logo,src:M,alt:"Weebin Logo"}),Object(E.jsxs)("div",{className:Y.a.Container,children:[Object(E.jsxs)("div",{className:Y.a.Sliders,children:[Object(E.jsx)(u,{className:Y.a.Slider,data:[d,O,l],delay:2}),Object(E.jsx)(u,{className:Y.a.Slider,data:[k,m,x],delay:4}),Object(E.jsx)(u,{className:Y.a.Slider,data:[h,f,N]})]}),Object(E.jsxs)("div",{className:Y.a.Actions,children:[!s()&&Object(E.jsx)(r,{onClick:function(){return A("/play")},className:Y.a.Play,children:"Play"}),Object(E.jsx)(r,{onClick:function(){return o("https://mivladie.github.io/gato/")},children:"Gato"}),Object(E.jsx)(r,{onClick:function(){return o("https://github.com/MiVladie/weebin",!0)},children:"GitHub"})]})]})]})]})},p=B(14),v=B.n(p),J=B(13),y=B.n(J),S=new p.UnityContext({loaderUrl:"project/Web.loader.js",dataUrl:"project/Web.data",frameworkUrl:"project/Web.framework.js",codeUrl:"project/Web.wasm"}),F=function(){var A=Object(t.useState)(0),g=Object(D.a)(A,2),B=g[0],C=g[1],Q=Object(I.f)();return Object(t.useEffect)((function(){s()&&Q("/"),S.on("progress",(function(A){C(A)}))}),[]),Object(E.jsxs)(E.Fragment,{children:[Object(E.jsx)(a.a,{children:Object(E.jsx)("title",{children:"Game | Weebin"})}),Object(E.jsxs)("div",{className:y.a.Main,children:[Object(E.jsx)("button",{className:y.a.Back,onClick:function(){return Q("/")},children:Object(E.jsx)("img",{src:"data:image/png;base64,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",alt:"back",width:"50",height:"50"})}),1!==B&&Object(E.jsxs)("p",{className:y.a.Loading,children:[Math.round(100*B),"%"]}),Object(E.jsx)(v.a,{unityContext:S,style:{width:"56.25vh",height:"100vh",backgroundColor:"#231F20"}})]})]})},_=function(){return Object(E.jsxs)(i,{children:[Object(E.jsx)(a.a,{children:Object(E.jsx)("title",{children:"Weebin"})}),Object(E.jsxs)(I.c,{children:[Object(E.jsx)(I.a,{path:"/",element:Object(E.jsx)(P,{})}),Object(E.jsx)(I.a,{path:"/play",element:Object(E.jsx)(F,{})})]})]})};Q.a.render(Object(E.jsx)(e.a,{basename:"/weebin",children:Object(E.jsx)(_,{})}),document.getElementById("root"))},6:function(A,g,B){A.exports={Main:"Home_Main__3rGV-",Logo:"Home_Logo__1tdr1",Container:"Home_Container__3IgY0",Sliders:"Home_Sliders__sviFo",Actions:"Home_Actions__38aI2",Play:"Home_Play__2cUfd"}}},[[34,1,2]]]);
//# sourceMappingURL=main.fe0068f2.chunk.js.map