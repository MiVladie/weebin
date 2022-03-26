import React, { useEffect, useState } from 'react';

import { Helmet } from 'react-helmet';
import { useNavigate } from 'react-router-dom';
import { isMobile } from 'util/screen';

import Unity, { UnityContext } from 'react-unity-webgl';

import back from 'assets/icons/back.png';

import classes from './Multiplayer.module.scss';

const unityContext = new UnityContext({
	loaderUrl: 'online/Builds.loader.js',
	dataUrl: 'online/Builds.data',
	frameworkUrl: 'online/Builds.framework.js',
	codeUrl: 'online/Builds.wasm'
});

const Multiplayer: React.FC = () => {
	const [progression, setProgression] = useState<number>(0);

	const navigate = useNavigate();

	useEffect(() => {
		if (isMobile()) {
			navigate('/');
		}

		unityContext.on('progress', (progression) => {
			setProgression(progression);
		});
	}, []);

	return (
		<>
			<Helmet>
				<title>Multiplayer | Weebin</title>
			</Helmet>

			<div className={classes.Main}>
				<button className={classes.Back} onClick={() => navigate('/')}>
					<img src={back} alt='back' width='50' height='50' />
				</button>

				{progression !== 1 && <p className={classes.Loading}>{Math.round(progression * 100)}%</p>}

				<Unity
					unityContext={unityContext}
					style={{ width: '56.25vh', height: '100vh', backgroundColor: '#231F20' }}
				/>
			</div>
		</>
	);
};

export default Multiplayer;
